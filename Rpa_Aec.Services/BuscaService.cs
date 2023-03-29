using AutoMapper;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Rpa_Aec.Domain.Entities;
using Rpa_Aec.Domain.Model;
using Rpa_Aec.Repository;
using Rpa_Aec.Repository.Entities.Interfaces;
using Rpa_Aec.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rpa_Aec.Services
{
    public class BuscaService : BackgroundService, IBuscaService
    {
        private readonly IBuscaRepository _buscaRepository;
        private readonly IMapper _mapper;

        private const string Url = "https://www.aec.com.br/";
        private const string BuscaVazia = "Busca vazia";
        private const string SemResultado = "Sem resultados";

        public BuscaService(IBuscaRepository buscaRepository, IMapper mapper)
        {
            _buscaRepository = buscaRepository;
            _mapper = mapper;
        }

        public async Task BuscaESalvaPalavra(string busca)
        {
            var buscaModel = BuscaPalavra(busca);
            if (buscaModel.Any())
            {
                var buscaMapped = _mapper.Map<List<Busca>>(buscaModel);
                await _buscaRepository.AddRange(buscaMapped);
            }
        }

        private ICollection<BuscaModel> BuscaPalavra(string busca)
        {
            IWebDriver chromeDriver = new ChromeDriver(Environment.CurrentDirectory);

            try
            {
                if (busca == string.Empty)
                {
                    throw new ArgumentNullException(BuscaVazia);
                }

                chromeDriver.Navigate().GoToUrl(Url);
                chromeDriver.Manage().Window.Maximize();

                AbreEPesquisaNaBarraDeBusca(busca, chromeDriver);
                var elementosDaBusca = LeElementos(chromeDriver);

                return elementosDaBusca;
            }
            catch (ArgumentNullException e) when (e.Message.Contains(BuscaVazia))
            {
                Console.WriteLine(e.Message);
                return default;
                throw;
            }
            catch (NotFoundException e) when (e.Message.Contains(SemResultado))
            {
                Console.WriteLine(e.Message);
                return default;
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
                throw;
            }
            finally
            {
                chromeDriver.Close();
            }
        }

        private static ICollection<BuscaModel> LeElementos(IWebDriver chromeDriver)
        {
            var listaDeBuscaModel = new List<BuscaModel>();

            var areas = chromeDriver.FindElements(By.ClassName("hat")).ToArray();
            var titulos = chromeDriver.FindElements(By.ClassName("tres-linhas")).ToArray();
            var detalhes = chromeDriver.FindElements(By.XPath("//small")).ToArray();
            var descricoes = chromeDriver.FindElements(By.ClassName("duas-linhas")).ToArray();

            if (areas.Length == 0)
            {
                throw new NotFoundException(SemResultado);
            }

            for (int i = 0; i < areas.Length; i++)
            {
                listaDeBuscaModel.Add(new BuscaModel()
                {
                    Area = areas[i].Text,
                    Titulo = titulos[i].Text,
                    Autor = BuscaModel.ExtraiAutor(detalhes[i].Text),
                    Descricao = descricoes[i].Text,
                    DataPublicacao = BuscaModel.ExtraiDataPublicacao(detalhes[i].Text)
                });
            }

            return listaDeBuscaModel;
        }

        private static void AbreEPesquisaNaBarraDeBusca(string busca, IWebDriver chromeDriver)
        {
            try
            {
                chromeDriver.FindElement(By.ClassName("buscar")).Click();
                chromeDriver.FindElement(By.Name("s")).SendKeys(busca);
                chromeDriver.FindElement(By.ClassName("me-3")).Click();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await BuscaESalvaPalavra("test");
        }
    }
}
