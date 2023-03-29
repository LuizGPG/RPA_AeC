# RPA_AeC

Projeto criado com objetivo de automatizar busca do site https://www.aec.com.br/ e armazenar resultados no banco de dados.

Codigo feito na abordagem DDD com foco no dominio, que nesse caso é o objeto de Busca, ou seja, o que é retornado da pesquisa e tratado.

<h1>Execução</h1>
Para executar o projeto é simples, tenha certeza que você possui o SQL Server instalado na sua maquina.
Opós isso, sera necessario criar uma base de dados com o nome <b>RPA_AEC</b>. Conforme imagem (opção "Novo Banco de Dados..."):

![image](https://user-images.githubusercontent.com/14313148/228533086-5b113f9a-7ca0-4c53-84ba-09fe967af94c.png)

Após isso executar o comando <b>update-database</b>. Eu executo pelo Package Manager Console desta maneira:
![image](https://user-images.githubusercontent.com/14313148/228533808-0c17f6a2-89bf-4996-83f1-def60b14f5c3.png)

Feito isso é só executar o programa.

<h1>Escolhas de tecnologias e ferramentas utilizadas:</h1>

<b>SQL Server</b>
<br>
Base relacional que facilita a criacao de entidades através de migrations. Além de uma base robusta e de facil manutenção.

<b>Entity Framework</b>
<br>
Lib com consolidada e com muita documentação disponível, alem de facilidades do uso.

<b>Microsoft.Extensions.Hosting</b>
<br>
Utilizada para a execução automatica do projeto assim que iniciada. Facil instanciação e documentção abrangente.
