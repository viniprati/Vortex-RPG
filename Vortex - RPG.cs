using System;
using System.Collections.Generic;
using System.Threading;
class Personagem{
  // Atributos da classe Personagem
  public int vida;
  public int vidaMaxima;
  public int ataque;
  public int defesa;
  public string nome;

  // Construtor da classe Personagem
  public Personagem(int vida, int ataque, int defesa, string nome){
    this.vida = vida;
    this.vidaMaxima = vida;
    this.ataque = ataque;
    this.defesa = defesa;
    this.nome = nome;
  }
  // Método para atacar outro personagem
  public void Atacar(Personagem personagemAlvo){
    if(this.ataque - personagemAlvo.defesa > 0){
    personagemAlvo.vida -= this.ataque - personagemAlvo.defesa;
      }
    else{
      Console.WriteLine(this.nome + " atacou " + personagemAlvo.nome + ", mas foi ineficaz!");
    }
  }
  // Método para receber dano
  public void ReceberDano(int dano){
    this.vida -= dano;
    if (this.vida < 0){
      this.vida = 0;
    }
  }
}
// Classe Inimigo que herda de Personagem
class Inimigo: Personagem{
  // Atributo da classe Inimigo
  public string tipo;

  // Construtor da classe Inimigo
  public Inimigo(int vida, int ataque, int defesa, string nome, string tipo, Heroi heroi): base(vida, ataque, defesa, nome){
    this.tipo = tipo;
  }
  // Método especial do inimigo
  public void Especial(Heroi heroi){
    // Move the if statement here:
    if (this.vida > 0)
    {
      Console.WriteLine(this.nome, "usou um ataque especial!");
      if(this.nome == "Dragão Bebê"){
        if((this.ataque*2) - heroi.defesa > 0){
        heroi.vida -= (this.ataque * 2) - heroi.defesa;
        Console.WriteLine(this.nome + " cuspiu uma bola de fogo em " + heroi.nome + "!");
          }
        else{
          Console.WriteLine(this.nome + " cuspiu uma bola de fogo em " + heroi.nome + ", mas foi ineficaz!");
        }
      }
      else if(this.nome == "Guerreiro Esqueleto"){
        if((this.ataque*2) - heroi.defesa > 0){
        heroi.vida -= this.ataque * 2;
        Console.WriteLine(this.nome + " desferiu um corte ósseo em " + heroi.nome + "!");
 }
        else{
          Console.WriteLine(this.nome + " desferiu um corte ósseo em " + heroi.nome + ", mas foi ineficaz!");
        }
      }
      else if(this.nome == "Gárgula"){
        if((this.ataque*2) - heroi.defesa > 0){
                heroi.vida -= this.ataque * 2;
                Console.WriteLine(this.nome + " liberou um rugido petrificante contra " + heroi.nome + "!");
         }
                else{
                  Console.WriteLine(this.nome + " liberou um rugido petrificante contra " + heroi.nome + ", mas foi ineficaz!");
                }
      }
    }
  }
}
// Classe DragaoBebe que herda de Inimigo
class DragaoBebe: Inimigo{

  // Construtor da classe DragaoBebe
  public DragaoBebe(int vida, int ataque, int defesa, string nome, string tipo, Heroi heroi): base(vida, ataque, defesa, nome, tipo, heroi){
    this.nome = "Dragão Bebê";
    this.tipo = "Dragão";
  }
  }
// Classe Esqueleto que herda de Inimigo
class Esqueleto: Inimigo{
  // Construtor da classe Esqueleto
  public Esqueleto(int vida, int ataque, int defesa, string nome, string tipo, Heroi heroi): base(vida, ataque, defesa, nome, tipo, heroi){
    this.nome = "Guerreiro Esqueleto";
    this.tipo = "Esqueleto";
  }
}
// Classe Gargula que herda de Inimigo
class Gargula: Inimigo{
  // Construtor da classe Gargula
  public Gargula(int vida, int ataque, int defesa, string nome, string tipo, Heroi heroi): base(vida, ataque, defesa, nome, tipo, heroi){
    this.nome = "Gárgula";
    this.tipo = "Monstro";
  }
}
// Classe Heroi que herda de Personagem
class Heroi: Personagem{
  // Atributos da classe Heroi
  public int level;
  public int xp;
  public string raca;
  public List<Item> meusitens = new List<Item>();

  // Método para adicionar itens ao inventário
  public void AdicionarItens(){
    meusitens.Add(new Arma("graveto", "Arma", 2));
    meusitens.Add(new Pocao("Poção de Cura", "Poção", 10));
  }


  // Construtor da classe Heroi
  public Heroi(int vida, int ataque, int defesa, string nome, int level, int xp, string raca): base(vida, ataque, defesa, nome){
    this.level = level;
    this.xp = xp;
    this.raca = raca;

    AdicionarItens();
  }
  // Método para ganhar XP
  public void GanharXp(int xpGanho){
    this.xp = this.xp + xpGanho;
    if(this.xp >= (this.level * 50) + 50 && this.level < 100){
      this.xp = 0;
      SubirDeNivel();
    }
  }
  // Método para subir de nível
  public void SubirDeNivel(){
    this.xp = 0;
    this.level = this.level + 1;
    this.vida = this.vidaMaxima;

      this.ataque += 2;
      this.defesa += 1;
      this.vidaMaxima += 5;
    this.vida = this.vidaMaxima;
  }
}
// Classe Item
class Item{
  // Atributos da classe Item
  public string nome;
  public string tipo;

  // Construtor da classe Item
  public Item(string nome, string tipo){
    this.nome = nome;
    this.tipo = tipo;
  }
  // Método para usar um item
  public void UsarItem(Heroi heroi){
  }
}
// Classe Arma que herda de Item
class Arma: Item{
  // Atributo da classe Arma
  public int poderataque;

  // Construtor da classe Arma
  public Arma(string nome, string tipo, int poderataque): base(nome, tipo){
    this.poderataque = poderataque;
  }
  // Método para equipar uma arma
  public void EquiparArma(Heroi heroi){
    if (heroi.meusitens.Exists(item => item.tipo == "Arma" && item != this))
    {
      Console.WriteLine("Você já está com uma arma equipada. Deseja desequipar a arma atual? (s/n)");
      string escolha = Console.ReadLine();
      if (escolha == "s")
      {
        foreach (Item item in heroi.meusitens)
        {
          if (item.tipo == "Arma" && item != this)
          {
            ((Arma)item).DesequiparArma(heroi);
            break;
          }
        }
      }
      else
      {
        return;
      }
    }
    heroi.ataque += this.poderataque;
  }
  // Método para desequipar uma arma
  public void DesequiparArma(Heroi heroi){
    heroi.ataque -= this.poderataque;
  }
}
// Classe Pocao que herda de Item
class Pocao: Item{
  // Atributo da classe Pocao
  public int quantidadeCura;

  // Construtor da classe Pocao
  public Pocao(string nome, string tipo, int quantidadeCura): base(nome, tipo){
    this.quantidadeCura = quantidadeCura;
  }
  // Método para usar uma poção
  public void UsarPocao(Heroi heroi){
    heroi.meusitens.Remove(this);
    Console.WriteLine("Você usou ", this.nome, "!");

    heroi.vida = Math.Min(heroi.vida + this.quantidadeCura, heroi.vida);
  }
}
// Classe Mundo
class Mundo{


  // Atributos da classe Mundo
  List<Personagem> personagens = new List<Personagem>();
  List<Inimigo> inimigos = new List<Inimigo>();
  List<Item> itens = new List<Item>();

  // Construtor da classe Mundo
  public Mundo(){
  }
  // Método para adicionar itens ao mundo
  public void AdicionarItem(){

    itens.Add(new Arma("Espada de Madeira", "Arma", 5));
    itens.Add(new Arma("Besta", "Arma", 10));
    itens.Add(new Pocao("Poção de Cura - (10)", "Poção", 10));
    itens.Add(new Arma("Espada de Ferro", "Arma", 20));
    itens.Add(new Pocao("Poção de Cura - (20)", "Poção", 20));
    itens.Add(new Arma("Marreta", "Arma", 15));
    itens.Add(new Pocao("Poção de Cura - (30)", "Poção", 30));
  }
  // Método para iniciar uma batalha
  public void IniciarBatalha(Heroi heroi, Inimigo i){}
  // Método para abrir o inventário
  public void AbrirInventario(Heroi heroi){
    Console.WriteLine("Inventário:");
        if (heroi.meusitens.Count == 0)
        {
          Console.WriteLine("Seu inventário está vazio.");
        }
        else
        {
          foreach (Item item in heroi.meusitens)
          {
            Console.WriteLine(item.nome);
          }
          Console.WriteLine("Deseja usar algum item ou sair do inventário? (s/n)");
          string escolhaInventario = Console.ReadLine();
          if (escolhaInventario == "s")
          {
            Console.WriteLine("Qual item deseja usar? (Digite o número correspondente)");
            int i = 1;
            foreach (Item item in heroi.meusitens)
            {
              Console.WriteLine($"{i} - {item.nome}");
              i++;
            }
            int escolhaItem = Convert.ToInt32(Console.ReadLine());
            if (escolhaItem > 0 && escolhaItem <= heroi.meusitens.Count)
            {
              Item itemEscolhido = heroi.meusitens[escolhaItem - 1];
              if (itemEscolhido.tipo == "Arma")
              {
                ((Arma)itemEscolhido).EquiparArma(heroi);
              }
              else if (itemEscolhido.tipo == "Pocao")
              {
                ((Pocao)itemEscolhido).UsarPocao(heroi);
              }
            }
            else
            {
              Console.WriteLine("Opção inválida.");
            }
          }
        }
}
  // Método para exibir o status do herói
  public void ExibirStatus(Heroi heroi){
    Console.WriteLine(heroi.nome.ToUpper());
    Console.WriteLine("Vida: " + heroi.vida + "/" + heroi.vidaMaxima);
    Console.WriteLine("Ataque:" + heroi.ataque);
    Console.WriteLine("Defesa:" + heroi.defesa);
    Console.WriteLine("Level:" + heroi.level);
    Console.WriteLine("Xp:" + heroi.xp + "/" + ((heroi.level * 50) + 50));
  }
  // Método para obter um item aleatório do mundo
  public Item GetRandomItem(){
    Random rnd = new Random();
    int itemIndex = rnd.Next(itens.Count);
    return itens[itemIndex];
  }
}
// Classe Batalha
class Batalha{

  // Método para iniciar uma batalha
  public void Batalhar(Heroi heroi, Mundo mundo){
    Boolean defesa = false;
    Random random = new Random();
    // Gera um número aleatório de inimigos
    int quantidadeInimigos = random.Next(1, 2);
    List<Inimigo> inimigos = new List<Inimigo>();
    // Cria inimigos aleatórios
    for (int i = 0; i < quantidadeInimigos; i++)
    {
      int escolhaInimigo = random.Next(1, 4);
      if (escolhaInimigo == 1)
      {
        inimigos.Add(new DragaoBebe((60 + heroi.level*5), (15 + heroi.level*1), (5+ heroi.level*1), "Dragão Bebê", "Dragão", heroi));
      }
      else if (escolhaInimigo == 2)
      {
        inimigos.Add(new Esqueleto((45 + heroi.level*5), (17 + heroi.level*1), (0 + heroi.level*1), "Guerreiro Esqueleto", "Esqueleto", heroi));
      }
      else if (escolhaInimigo == 3){
        inimigos.Add(new Gargula((50 + heroi.level*5), (18 + heroi.level*1), (0 + heroi.level*1), "Gárgula", "Monstro", heroi));
      }
    }
    Console.WriteLine("Você encontrou um inimigo!");
    // Exibe os inimigos encontrados
    foreach (Inimigo inimigo in inimigos)
    {
      Console.WriteLine(inimigo.nome + " - tipo:" + inimigo.tipo);
      if (inimigo.nome == "Dragão Bebê"){
        Console.WriteLine(@"
                                             .~7????7~:.         
                          .               .!?7~::::~7???!^.      
                         7P?~.          :JY7~^^:...:~!?J??7!:    
                    ~J5P5GBG5J7.      .YP?!~~~~^:.:.^~!?JJJ?7!:  
                 7G&@&&&&#G55JJJ7~^. :P57^:.......:::    .:!?77~ 
               .P@&&&&&#BY55G&BJ?!!:.JJ7.         ..        ^~:. 
           .7G#BYJB#PPPP5Y? .5&#Y7!:!??^                         
          ^#@&&BJ?B#5YYYYYYJ5GGPP5JJYYJ!                         
          #&&######B55555YY5555555YJYYYY?~:                      
          PGG5YJ?JJ?!?777??77?7~:~???Y5YY555!.                   
            .:.. :P^~!:. .   . .!7YJ?YYYPB##BGJ!                 
                 ~BY?7~:...:::::JP5J?77YB#&###BGJ^...    .:..    
                 J5GY!~~~^!~~!!^7GYJ?!~!5#&##BBP55555J!?Y5YJY~   
                 P7!J7^~!7!7JYJ7?J???~^^7G###BGP5Y55555555J??.   
                :BY7~^^7?7?Y555?7??7~^^775PGGGGP5YY55555YYJJ.    
                P577!7PP5YY55YJ777!^^7YPPPPPP5555YY55555YYY~     
               .BPJYBY5P5YYJ7?7!!~~7J5P5YJJYYYYYYYYY55555YJ      
               :BP?JBG55J7!!~!!~!7Y555YY?7777???????JYYYYY~      
             ..PPPGGGPY?7~~~~~^7PPP55YJ?7!~^^~~!!!!7?JJJYJJ!.    
            ~ ~G5J!~!77~^^^^7?!?Y7J5Y7~!~~^^~~!!~~!7???JJJJJJ?^. 
           .?  JJ7:   .      ^?JJ77?7~^~~~!!!77!!7JJJJ??JJ?????7.
            :.                 .7YYJ?7777!!!!!~~^^?GP5YJJJ??7777:
                                  :!???7!~~^^^^^^~~:^^~!77!!~~!!^
                                      ^~!!!~~~~~!~          ...  
                                         :^~~~!77!.              
              .                                .:.               ");
      }
      else if(inimigo.nome == "Guerreiro Esqueleto"){
        Console.WriteLine(@"
                                       .^7YGGGY~                 
                                    ~P#@@@@@@@@@&7               
                                  !&@&&#&&&@@@@@@@B7             
                       :  .:.    :&&##BBBB#&#GP#@#7J.            
                  ..:^YP7P&&P~:  ~##BBBGGGG!  .7#B.7^            
            7J5GB##&&&&G5&GGP..  .GBBBBBBB#J::7B&Y^B&~           
           G@&&&&&#BBGPYYJYY5^    ^BGGPY?75BGBB##B&@P.    ~^^    
            :77~^:.     .. .?B     .5J~~^:^~!::77!!~  .Y:!GB#BP. 
                             Y#^      ....!:^:         :7~~~^:JJ 
                             :#B5!^.:!^:. ~7:^..~PG~~~~~:.       
                              ::.:~7BGY~755YY5PYYB?:^~:          
                                     .!!?Y5PGGG7!G~              
                                       J#GP5P55!:J5.             
                                       YG5P5PJYJ:?5~             
                                       ^PY55G5!^....             
                                       :#5YYYJJ??Y!  ..          
                                        P5!?5YJP7^!?PG5          
                                 ::     Y?~!J?Y7    7GY ::.      
                                7BGP^  ~P!          ?G.7BG#~     
                               :PYJGB5J55J         J##P5?77      
                              .YJ7^^!.  :.         YB57^.        
                                                   :Y7:          

");
      }
      else if(inimigo.nome == "Gárgula"){
        Console.WriteLine(@"
                               .                                 
                               YY.             ~Y^               
                               5YP^            ~GP?              
                               J??P!           5J5P              
                   ...::..     .J!75J.        !7?YJ              
              .:^^::::..:::.    ^7~~JJ:      ~~7?7.              
             !7~:.::....:::::..  ~!^^!!~!^!~~^~77^.::^^^^:.      
             !^^^:.         .:.^^~^:::~YGGBG5J7~:..::...:^!!~:   
           .. ~^           .:::::^7!~?55PGB###B?    .::^:::~^    
                      .^::...::::^YY?PBBBBBBBB#B~     .:^: ..    
                    .7J!^^:::::::!Y~?P?YPGGPYYYBG~               
                  .!YY7!~^^::::::75~^~::^75BP?YGB#5:             
                 ~?7!!~~^::^^:::::Y7~!7?77PBGGGJPBBY7^           
               .7~^^^^^::7J7!!^::.^?^^77~^?5YY!::^!^?5J.         
              !~!!!^... .PY7~^^:::.:77^^^^~?!  ^..:~!JYY:        
             ~!~!~~^..  :7^~~~^::::~7J7:..     .^:..:!?YJ        
             ?~~~~~^.   .!...:~^^:^~~^.          .::^^~Y5.       
             7~~~!!~^:.  7:.   .:.:.              ^:^~~?J.       
             ^7^^~!7?!^: ~~.     .              . .::~^!J        
              ?!^^~77  ......                   .....~?J:        
              .J!^:~J:     .                      .:~7~.         
                ^^:.:!!~.                                        
                  ....:.                                         
");
      }

    }
    // Inicializa variáveis para controle do loop da batalha
    int turno = 0;
    int probabilidade;
    Boolean batalha = false;
    // Loop da batalha
    while (heroi.vida > 0 && inimigos.Count > 0 && !batalha)
    {
      turno++;
      Console.WriteLine("Turno " + turno);
      if (turno % 5 == 4){
        Console.WriteLine(inimigos[0].nome + " terminou de carregar seu ataque especial!");
      }
      // Se o turno não for múltiplo de 5, os inimigos atacam
      if (turno % 5 != 0)
      {
        foreach (Inimigo inimigo in inimigos)
        {
          if (inimigo.vida > 0)
          {
            inimigo.Atacar(heroi);
            Console.WriteLine(inimigo.nome + " atacou você!");
            Console.WriteLine(" ");
            Console.WriteLine("Sua vida: " + heroi.vida);
          }
        }
      }
      // Se o turno for múltiplo de 5, os inimigos usam seus ataques especiais
      else
      {
        foreach (Inimigo inimigo in inimigos)
        {
          if (inimigo.vida > 0)
          {
            inimigo.Especial(heroi);
            Console.WriteLine("Sua vida: " + heroi.vida);
          }
        }
      }

      // Verifica se o herói está defendendo e reduz sua defesa
      if(defesa == true){
        defesa = false;
        heroi.defesa = heroi.defesa/2;
      }
      // Verifica se o herói morreu
      if (heroi.vida <= 0)
      {
        foreach (char c in "Você foi derrotado!"){
          Console.Write(c);
          Thread.Sleep(150);
        }
        Console.WriteLine(@"
 ____    ____  ______   .______     .___________. __________   ___ 
 \   \  /   / /  __  \  |   _  \    |           ||   ____\  \ /  / 
  \   \/   / |  |  |  | |  |_)  |   `---|  |----`|  |__   \  V  /  
   \      /  |  |  |  | |      /        |  |     |   __|   >   <   
    \    /   |  `--'  | |  |\  \----.   |  |     |  |____ /  .  \  
     \__/     \______/  | _| `._____|   |__|     |_______/__/ \__\ 
        ");
        foreach (char c in "Fim de Jogo."){
          Console.Write(c);
          Thread.Sleep(1500);
        }
        batalha = true;
      }
      // Se o herói estiver vivo, é a vez dele
      else{
        Console.WriteLine("");
      Console.WriteLine("Seu turno:");
      foreach (char c in "O que irá fazer?\n"){
        Console.Write(c);
        Thread.Sleep(50);
      }
      Console.WriteLine(@"1 - Atacar
2 - Usar Item
3 - Defender
4 - fugir");
      int opcao = Convert.ToInt32(Console.ReadLine());
      // Verifica a ação do herói
      if (opcao == 1)
      {
          Console.WriteLine("");
          // Check if there are enemies before accessing the list
          if (inimigos.Count > 0) 
          {
            heroi.Atacar(inimigos[0]);
            Console.WriteLine("Você atacou " + inimigos[0].nome + "!");
            Console.WriteLine(inimigos[0].nome + " vida: " + inimigos[0].vida);
            // Verifica se o inimigo morreu
            if (inimigos[0].vida <= 0)
            {
              Console.WriteLine(inimigos[0].nome + " foi derrotado!");
              inimigos.RemoveAt(0);
                  Console.WriteLine("");
                  Console.WriteLine("Você venceu a batalha!");
                  Item loot = mundo.GetRandomItem();
                  heroi.meusitens.Add(loot);
                  Item loot2 = mundo.GetRandomItem();
                  heroi.meusitens.Add(loot2);
                  Console.WriteLine("Você encontrou: " + loot.nome + " e " + loot2.nome);
              heroi.GanharXp(75);
              batalha = true;
              }
            }
          }
      // Se o herói escolher usar item
      else if (opcao == 2)
      {
        mundo.AbrirInventario(heroi);
      }
      // Se o herói escolher defender
      else if (opcao == 3)
      {
        Console.WriteLine("");
        // defender
        defesa = true;
        heroi.defesa += heroi.defesa;
        Console.WriteLine("Você se defendeu, duplicando sua defesa! ");
      }
      // Se o herói escolher fugir
      else if (opcao == 4)
      {
        // fugir
        probabilidade = random.Next(1, 101);
        if (probabilidade <= 30){
          Console.WriteLine("");
          Console.WriteLine("Você fugiu da batalha!");
          batalha = true;
        }
        else{
          Console.WriteLine("");
          Console.WriteLine("Você não conseguiu fugir!");
        }
      }
   }
  }
 }
}
// Classe principal do programa
class Program {
  public static void Main (string[] args) {
    // Cria objetos para o mundo e a batalha
    Mundo mundo = new Mundo();
    Batalha batalha = new Batalha();
    // Adiciona itens ao mundo
    mundo.AdicionarItem();

    Console.WriteLine(@"
      ____    ____  ______   .______     .___________. __________   ___ 
      \   \  /   / /  __  \  |   _  \    |           ||   ____\  \ /  / 
       \   \/   / |  |  |  | |  |_)  |   `---|  |----`|  |__   \  V  /  
        \      /  |  |  |  | |      /        |  |     |   __|   >   <   
         \    /   |  `--'  | |  |\  \----.   |  |     |  |____ /  .  \  
          \__/     \______/  |__| `._____|   |__|     |_______/__/ \__\ 
");
    Thread.Sleep(3000);
    // Apresenta o jogo ao jogador
    foreach (char c in "Saudações, mortal. Receba as boas-vindas a um mundo totalmente novo.\n")
    {
      Console.Write(c);
      Thread.Sleep(50);
    }
    foreach (char c in "Um mundo repleto de novos desafios, numerosos inimigos e inúmeras maldições.\n")
    {
      Console.Write(c);
      Thread.Sleep(50);
    }
    foreach (char c in "Contudo, é também um reino de grande gozo, heroísmo e abundantes bênçãos.\n")
    {
      Console.Write(c);
      Thread.Sleep(50);
    }
    foreach (char c in "De fato, apenas o herói mais audacioso conseguirá sobreviver a esta jornada...\n")
    {
      Console.Write(c);
      Thread.Sleep(50);
    }
    Thread.Sleep(2000);
    foreach (char c in "Estás preparado para iniciar?(s/n)\n")
    {
      Console.Write(c);
      Thread.Sleep(50);
    }
    // Verifica se o jogador deseja iniciar o jogo
    if(Console.ReadLine() == "s"){
      Console.WriteLine(@"");
      foreach (char c in "Excelente.\n")
      {
        Console.Write(c);
        Thread.Sleep(50);
      }
      Thread.Sleep(2000);
      Thread.Sleep(3000);
      foreach (char c in "Profira o nome que lhe convém:\n")
      {
        Console.Write(c);
        Thread.Sleep(50);
      }
    // Le o nome do jogador
    string nome = Console.ReadLine();
      Console.WriteLine(@"");
      foreach (char c in "Excelente.\n")
      {
        Console.Write(c);
        Thread.Sleep(50);
      }
      Thread.Sleep(2000);
      // Permite que o jogador escolha sua raça
      Console.WriteLine(@"Escolha sua espécie: (Indique o número correspondente)
1 - fada
2 - sereia/tritão
3 - humano");
      int escolha = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine(@"");
      foreach (char c in "Perfeito.\n")
      {
        Console.Write(c);
        Thread.Sleep(50);
      }
      // Cria o herói com base na escolha do jogador
      Heroi heroi = null;
      if(escolha == 1){
      heroi = new Heroi(55, 8, 15, nome, 0, 0, "fada");
      }
      else if(escolha == 2){
      heroi = new Heroi(75, 14, 8, nome, 0, 0, "sereia/tritão");
      }
      else if(escolha == 3){
      heroi = new Heroi(75, 11, 11, nome, 0, 0, "humano");
      }
      Console.WriteLine(@"");
      Thread.Sleep(3000);
      foreach (char c in "Seu personagem encontra-se integralmente desenvolvido.\n")
      {
        Console.Write(c);
        Thread.Sleep(50);
      }
      Thread.Sleep(1500);
      foreach (char c in "Espero que suas decisões lhe tragam satisfação:\n")
      {
        Console.Write(c);
        Thread.Sleep(50);
      }
      Thread.Sleep(2000);
      Console.WriteLine(@"");
      // Exibe o status do herói
      mundo.ExibirStatus(heroi);
      Console.WriteLine(@"");

      Thread.Sleep(4000);
      foreach (char c in "Agora, podemos iniciar sua jornada. Que a sorte esteja ao seu favor.\n")
      {
        Console.Write(c);
        Thread.Sleep(50);
      }
      foreach (char c in "...\n")
      {
        Console.Write(c);
        Thread.Sleep(1000);
      }
      Console.WriteLine(@"");
      Console.WriteLine(@"");
      Console.WriteLine(@"");
      Console.WriteLine(new string(' ', Console.WindowHeight));
      foreach (char c in "Você se levanta em um cenário desconhecido, sem a menor ideia de como chegou a esse lugar.\n"){
        Console.Write(c);
        Thread.Sleep(50);
      }
      // Loop principal do jogo
      Boolean a = true;
      while(a == true){Console.WriteLine("");
      Console.WriteLine("O que irá fazer?");
      Console.WriteLine(@"1 - Luta
2 - Abrir inventário
3 - Verificar personagem
4 - Sair");

      // Le a escolha do jogador
      int opcao = Convert.ToInt32(Console.ReadLine());
      // Verifica a escolha do jogador
      if (opcao == 2)
      {
        Console.WriteLine("");
        mundo.AbrirInventario(heroi);
      }
      // Se o jogador escolher lutar
      else if(opcao == 1){
        Console.WriteLine("");
        batalha.Batalhar(heroi, mundo);
      }
        // Se o jogador escolher verificar o personagem
        else if(opcao == 3){
          Console.WriteLine("");
          mundo.ExibirStatus(heroi);
        }
        // Se o jogador escolher sair do jogo
        else if (opcao == 4){
          Console.WriteLine("");
          Console.WriteLine(@"
           ____    ____  ______   .______     .___________. __________   ___ 
           \   \  /   / /  __  \  |   _  \    |           ||   ____\  \ /  / 
            \   \/   / |  |  |  | |  |_)  |   `---|  |----`|  |__   \  V  /  
             \      /  |  |  |  | |      /        |  |     |   __|   >   <   
              \    /   |  `--'  | |  |\  \----.   |  |     |  |____ /  .  \  
               \__/     \______/  | _| `._____|   |__|     |_______/__/ \__\ 
                  ");
                  foreach (char c in "Fim de Jogo."){
                    Console.Write(c);
                    Thread.Sleep(1500);}
                    return;
        }

        // Verifica se o herói está vivo
        if(heroi.vida <= 0){
          a = false;
        }
          }
        }
      }
  }