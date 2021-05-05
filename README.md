# InventarioProject

Esse é um projeto que tem como objetivo implementar alguns conhecimentos obtidos no decorrer do curso de Ciência da computação e também de desafios do Grupo de Jogos do mesmo.

Aqui explicarei com detalhes como foi feito o processo de desenvolvimento até chegar no final do produto que é o jogo rodando.

O contexto de tudo é que foi lançado um desafio no grupo de jogos de construir um inventário com as seguintes características:

```
Desenvolvam um sistema de inventário, equipamento e atributos em C#, com itens:

1. Equipáveis (são enviados o menu de equipamento quando usados, e se algo estiver naquele slot específico, o item 
que JÁ estava equipado sairá do mesmo de volta ao inventário, sendo substituído pelo utilizado)
2. Consumíveis (são consumidos ao usa-los)
3. Etc (não pode se interagir com esses, retornar mensagem de erro)

Os seguintes slots/tipos de equipamento:

1. Capacete
2. Armadura
3. Botas
4. Luvas
5. Anel

E os seguintes atributos:

1. STR
2. AGI
3. DEX
4. LUK
```

E assim, se inicia o desenvolvimento!

## PARTE 1: Para que serve a organização? 🤔

Nessa primeira parte eu gostaria de dar um bom e belo exemplo de como planejar as coisas antes de sair codando pode ser uma boa prática, ainda mais quando se não tem certeza
de como irá criar as relações das suas classes.

A imagem abaixo representa um esquema que fiz pensando de início de como ficaria a relação das classes, essa pequena monstruosidade saiu da minha própria cabeça:

<img src="https://i.ibb.co/3RpSgYX/sem-padr-o.png" width="100%"/>

Perceba como a relação entre <b>atributos</b> e <b>características</b> não faz muito <i>sentido</i> e foi nesse momento que me veio o primeiro insight


 <i>"Organizar isso seria bom, <b>padronizar</b> seria perfeito."</i>

E foi nesse momento que fui atrás de um padrão de projeto que atendesse as minhas espectativas, o que eu sabia era

- Eu tenho um conjunto de itens com características semelhante
- Eu preciso instanciar eles de alguma forma organizada (Spawnar os sets)
- Eu preciso manusear os itens de alguma forma

E com isso eu fui levado direto ao primeiro padrão: Factory Method

Vamos ver o que o site <a href="https://refactoring.guru/pt-br/design-patterns/factory-method">refactoring.guru</a> diz sobre ele

  <i>"O Factory Method é um padrão criacional de projeto que fornece uma interface para criar objetos em uma superclasse, mas permite que as subclasses alterem o tipo de objetos que serão criados."</i>

Bem, de cara já vemos uma certa ligação com o primeiro item, depois de ler e entender como o padrão é aplicado, desenvolvi outro diagrama seguindo suas regras

<img src="https://i.ibb.co/4PStMKk/Factory-Method.png"/>

Percebam a evolução de tentar criar algo <i>na doida</i> e de ir seguindo uma organização.

Agora já temos uma coisa mais concreta, uma interface equipamento que irá conter os atributos, uma classe abstrata ferreiro que conterá um método que devolverá um objeto do tipo equipamento,
 duas classes de helmos de classes diferentes que herdam de equipamento, duas classes de ferreiro, com cada ferreiro responsável por uma linha de item. 
 
 Por mais que dessa vez o diagrama já esteja mais organizado, ainda sim me encontrei com um problema com o factory method:
 
 <i>"Se eu for ter que criar um ferreiro pra cada tipo de item, pra cada item, isso vai ficar muito grande e muito complexo. Seria bom que cada ferreiro ficasse responsável
 por uma linha de item"</i>
 
 E foi assim que cheguei no Abstract Factory, que segundo o guru:
 
  <i>"O Abstract Factory é um padrão de projeto criacional que permite que você produza famílias de objetos relacionados sem ter que especificar suas classes concretas."</i>
  
  Agora sim! Com isso foi definitivo, segui as instruções que o guru dá e então saiu isso aqui:
  
  <img src="https://i.ibb.co/qpPH8Cw/Itens-Rela-o.png"/>
  
  Eita! Agora ficou um pouquinho maior as coisas, mas não esquenta, foi só pra exemplificar como vai funcionar a expansão dele. 
  
  Vamos do início, a primeira coisa a se explicar aqui é a interface comum a todas as classes dos itens, que é a dita cuja Itens. Nela foi declarado apenas um atributo/método Nome.
  Em seguida vamos seguir pela linha da direita, agora temos uma nova interface chamada <b>Equipamento</b> que possui todos os atributos que um equipamento deve ter.
  Logo abaixo vemos 2 classes de uma mesma linha: <b>HelmoGuerreiro</b> e <b>ArmaduraGuerreiro</b> que herdam de <b>Equipamento</b>.
  
  Agora voltando um pouco pra cima, vemos uma outra interface chamada <b>Ferreiro</b> que <b>contém</b> a classe equipamento. Ela possui dois métodos que são: <b>criarHelmo()</b> e <b>criarArmadura()</b>
  conforme for aumentando a linha de produtos daquele tipo irá aumentar o número de métodos também, seguindo o mesmo padrão. Abaixo da interface vemos uma classe chamada FerreiroDeGuerreiro, que como o nome já diz, ficará responsável apenas pelos itens da classe guerreiro.
  
  Agora vamos olhar um pouco para a esquerda, se pararmos para observar:
  
  - a interface consumível pode fazer um paralelo com a interface equipamento
  - as classes de poteVida e poteMana fazem paralelo com as classes HelmoGuerreiro e ArmaduraGuerreiro
  - a interface Mercado faz um paralelo com Ferreiro
  - a classe MercadoVila faz um paralelo com FerreiroDeGuerreiro
  
 Isso *****, agora sim temos um padrão, temos organização e sabemos a importância dela. 
 
 Agora para finalizar, uma pequena explicação sobre a última classe <b>Inventario<b> que está <i>alone</i> que é a Inventario. Essa classe irá conter duas listas, uma para os itens gerais e outra específica para equipamentos e conterá alguns métodos mais complexos que irei explicar abaixo na codificação.
 Bem, já tô ansioso, chega de diagramas e vamos mandar bala na codificação!
 
 ## PARTE 2: Não basta funcionar, tem que ser legível
 
 <h3> <i>EM PRODUÇÃO</i> </h3>
 
 
 
 
