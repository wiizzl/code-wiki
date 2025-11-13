using CodeWiki.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace CodeWiki.Services;

public partial class DatabaseService
{
    private SQLiteConnection _database;
    public const string DatabaseFilename = "data.db3";
    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
          
    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    
    public DatabaseService()
    {
        _database = new SQLiteConnection(DatabasePath, Flags);

        var resetDatabase = false;
        if (!resetDatabase) return;
        
        _database.CreateTable<Language>();
        _database.CreateTable<Distro>();
        _database.CreateTable<Database>();

        _database.DeleteAll<Language>();
        _database.DeleteAll<Distro>();
        _database.DeleteAll<Database>();
            
        _database.Insert(new Language()
        {
            Name = "JavaScript",
            Creator = "Brendan Eich",
            ReleaseYear = 1995,
            Description = "Le roi du web, adulé et détesté à la fois. JavaScript, c’est comme un couteau suisse : ça fait tout, mais parfois ça coupe les doigts. Grâce à lui, tu peux rendre un site dynamique… ou le faire planter en 3 lignes de code. Et n’oublions pas Node.js, qui a permis aux devs de faire du backend en JS, parce que pourquoi pas ?",
            ImageSource = "languages/js.png",
            MemeDescription = "Ce meme pourrait montrer une personne confuse avec une expression de désespoir et les symboles \"==\" et \"===\". Il illustre la confusion fréquente entre les opérateurs de comparaison en JavaScript. L'opérateur == effectue une comparaison de valeurs avec conversion de type, tandis que === effectue une comparaison stricte, sans conversion de type. Cela peut mener à des résultats inattendus et est souvent une source de bugs pour les développeurs.",
            MemeSource = "languages/memes/js_meme.jpg"
        });

        _database.Insert(new Language()
        {
            Name = "C#",
            Creator = "Anders Hejlsberg",
            ReleaseYear = 2000,
            Description = "Le langage préféré de Microsoft, propre, élégant, et un peu trop corporate. C#, c’est comme un costume trois-pièces : ça fait pro, mais des fois tu te demandes si tu ne devrais pas mettre un jean. Avec .NET, tu peux tout faire… à condition d’aimer les acronymes et les mises à jour qui cassent tout.",
            ImageSource = "languages/cs.png",
            MemeDescription = "Ce meme montre une scène avec des manchots qui semblent indifférents, suivie d’une réaction exagérée d’un manchot qui s’exclame : \"A GAME DEVELOPER\". Il illustre le stéréotype selon lequel le langage C# est principalement associé au développement de jeux vidéo (notamment avec le moteur Unity). Le meme souligne l’idée que les gens ne pensent qu’au jeu vidéo quand on mentionne C#, alors que ce langage est utilisé dans bien d’autres domaines.",
            MemeSource = "languages/memes/cs_meme.png"
        });

        _database.Insert(new Language()
        {
            Name = "Python",
            Creator = "Guido van Rossum",
            ReleaseYear = 1991,
            Description = "Le langage des paresseux intelligents. Python, c’est comme un chat : mignon, facile à vivre, et ça fait le café (ou presque). Avec ses indentations obligatoires, il t’apprend à être propre… ou à détester les espaces. Et grâce à ses librairies, tu peux faire du machine learning en 5 lignes. Magique, non ?",
            ImageSource = "languages/py.png",
            MemeDescription = "Ce meme illustre avec humour les stéréotypes autour des développeurs selon leur langage de programmation en utilisant une référence à \"Kiki's Delivery Service\" : les programmeurs Java et C++, représentés en train de voler activement sur des balais, symbolisent la complexité et l'effort requis pour maîtriser ces langages, tandis que le développeur Python, debout détendu sur un robot aspirateur, incarne la simplicité et l'efficacité de Python, où le langage semble faire une grande partie du travail à leur place.",
            MemeSource = "languages/memes/py_meme.png"
        });

        _database.Insert(new Language()
        {
            Name = "Java",
            Creator = "James Gosling",
            ReleaseYear = 1995,
            Description = "Le langage qui a survécu à tout, même à lui-même. Java, c’est comme un vieux tank : lent, lourd, mais incroyablement résistant. Avec sa machine virtuelle, il te promet de tourner partout… à condition d’avoir 5 Go de RAM. Et n’oublions pas les `NullPointerException`, le cadeau d’anniversaire que tout dev Java mérite.",
            ImageSource = "languages/java.png",
            MemeDescription = "Ce meme utilise des images de SpongeBob pour illustrer la différence de simplicité entre les langages de programmation. Python est représenté comme simple et direct avec print, tandis que C++ et Java sont montrés comme plus verbeux et compliqués avec cout et System.out.println. Le meme souligne l’idée que Python est plus accessible pour les débutants, tandis que les autres langages demandent plus de syntaxe.",
            MemeSource = "languages/memes/java_meme.jpeg"
        });

        _database.Insert(new Language()
        {
            Name = "C++",
            Creator = "Bjarne Stroustrup",
            ReleaseYear = 1985,
            Description = "Le langage des puristes et des masochistes. C++, c’est comme une voiture de course : ultra-rapide, ultra-puissante, et si tu te rates, tu finis dans le décor. Avec ses pointeurs, ses références et son héritage multiple, il te rappelle que la liberté a un prix… et que ce prix, c’est ta santé mentale.",
            ImageSource = "languages/cpp.png",
            MemeDescription = "Ce meme utilise une image d’un homme musclé et souriant pour représenter les programmeurs C++ comme des \"dieux modernes\". Le C++ est un langage de programmation réputé pour sa complexité, sa puissance et sa performance. Le meme joue sur l’idée que maîtriser ce langage est un exploit quasi-divin, souvent réservé à une élite de développeurs.",
            MemeSource = "languages/memes/cpp_meme.jpg"
        });

        _database.Insert(new Language()
        {
            Name = "PHP",
            Creator = "Rasmus Lerdorf",
            ReleaseYear = 1994,
            Description = "Le langage qui refuse de mourir. PHP, c’est comme un vieux frigo : ça marche (à peu près), mais personne ne sait vraiment pourquoi. Malgré ses incohérences légendaires et sa syntaxe qui semble écrite par un chat marchand sur le clavier, il alimente encore 80% du web. Preuve que la technologie, parfois, c’est juste une question de timing.",
            ImageSource = "languages/php.png",
            MemeDescription = "Ce meme montre Winnie l'ourson avec une expression choquée et le mot \"explode\". Il joue sur le fait que PHP utilise la fonction explode() pour diviser une chaîne de caractères, un nom qui semble violent et disproportionné par rapport à des fonctions similaires dans d'autres langages comme split(). Cela reflète l'humour autour des choix de nommage parfois surprenants de PHP.",
            MemeSource = "languages/memes/php_meme.jpg"
        });

        _database.Insert(new Language()
        {
            Name = "Ruby",
            Creator = "Yukihiro Matsumoto",
            ReleaseYear = 1995,
            Description = "Le langage des poètes et des hippies du code. Ruby, c’est comme un haïku : beau, élégant, et un peu mystérieux. Avec Rails, il t’a promis de rendre le développement web « magique »… et il a tenu parole, à condition d’accepter que la magie, parfois, cache des sorts un peu sombres.",
            ImageSource = "languages/rb.png"
        });

        _database.Insert(new Language()
        {
            Name = "Go",
            Creator = "Google (Robert Griesemer, Rob Pike, Ken Thompson)",
            ReleaseYear = 2009,
            Description = "Le langage des gens pressés (et de Google). Go, c’est comme un vélo de course : simple, efficace, et sans fioritures. Avec ses goroutines, il te promet la concurrence sans mal de crâne… à condition d’oublier les génériques et l’héritage. Parce que chez Go, on fait du code, pas de la philosophie.",
            ImageSource = "languages/go.png",
            MemeDescription = "Ce meme montre un personnage d’Office Space (un film culte) avec une expression confiante et un mug à la main. Il joue sur l’idée que les développeurs qui utilisent Go (ou Golang) sont tellement convaincus des avantages de ce langage (simplicité, performance, concurrency) qu’ils le proposent comme solution universelle, peu importe le problème.",
            MemeSource = "languages/memes/go_meme.jpg"
        });

        _database.Insert(new Language()
        {
            Name = "Rust",
            Creator = "Graydon Hoare",
            ReleaseYear = 2010,
            Description = "Le langage des perfectionnistes et des paranoïaques de la mémoire. Rust, c’est comme un casque de moto : sûr, solide, mais un peu lourd à porter. Avec son borrow checker, il te protège de toi-même… et des bugs. Le seul langage où le compilateur te fait la morale avant même que ton code ne tourne.",
            ImageSource = "languages/rs.png",
            MemeDescription = "Ce meme montre un crabe tenant des armes, avec le mot \"unsafe\" en haut. Il fait référence au mot-clé unsafe en Rust ou en C#, qui permet d'écrire du code qui contourne certaines vérifications de sécurité du langage. Le meme joue sur l'idée que l'utilisation de unsafe est risquée et dangereuse, comme un crabe armé.",
            MemeSource = "languages/memes/rs_meme.jpg"
        });

        _database.Insert(new Language()
        {
            Name = "Swift",
            Creator = "Apple Inc.",
            ReleaseYear = 2014,
            Description = "Le langage chic et branché d’Apple. Swift, c’est comme un iPhone : beau, intuitif, et un peu cher à maintenir. Avec sa syntaxe propre et ses mises à jour régulières, il te rappelle que chez Apple, on ne fait pas que des téléphones, on fait aussi des devs heureux… ou presque.",
            ImageSource = "languages/swift.png",
            MemeDescription = "Ce meme critique l'industrie technologique et les entreprises qui exigent plusieurs années d'expérience avec des technologies très récentes, comme SwiftUI d'Apple. SwiftUI a été annoncé en 2019, donc demander cinq ans d'expérience juste après son lancement est absurde et irréaliste.",
            MemeSource = "languages/memes/swift_meme.jpg"
        });

        _database.Insert(new Distro()
        {
            Name = "Ubuntu",
            Family = "Debian",
            ReleaseYear = 2004,
            Description = "La distribution Linux pour ceux qui veulent se sentir hackers… sans trop se fatiguer. Ubuntu, c’est comme un café Starbucks : partout, accessible, et un peu trop mainstream pour les puristes. Avec son interface conviviale et ses mises à jour régulières, c’est le Linux que ta grand-mère pourrait (peut-être) utiliser. Enfin, si elle savait ce que c’est qu’un terminal.",
            ImageSource = "distros/ubuntu.png",
            MemeDescription = "Ce meme montre une personne avec un air sérieux et un sac à dos, soulignant une distinction importante dans la communauté Linux : dire \"Linux\" ne se limite pas à Ubuntu. Cela reflète l'idée que beaucoup de gens associent Linux uniquement à Ubuntu, alors qu'il existe une multitude de distributions, chacune avec ses spécificités et ses utilisateurs dévoués.",
            MemeSource = "distros/memes/ubuntu_meme.jpg"
        });

        _database.Insert(new Distro()
        {
            Name = "Fedora",
            Family = "Red Hat",
            ReleaseYear = 2003,
            Description = "Le terrain de jeu des devs et des early adopters. Fedora, c’est comme un prototype de voiture électrique : innovant, un peu instable, mais toujours à la pointe. Si tu veux tester les dernières technologies avant tout le monde (et casser ton système au passage), c’est la distro qu’il te faut. Sponsorisée par Red Hat, donc tu peux faire semblant d’être un pro.",
            ImageSource = "distros/fedora.png"
        });

        _database.Insert(new Distro()
        {
            Name = "Debian",
            Family = "Indépendante",
            ReleaseYear = 1993,
            Description = "Le grand-père sage et respecté du monde Linux. Debian, c’est comme un vieux livre de bibliothèque : solide, fiable, et un peu poussiéreux. Si tu veux une distro qui ne te lâchera jamais (même après 10 ans), c’est ton choix. Par contre, prépare-toi à compiler des paquets à la main, parce que ici, on ne fait pas les choses à moitié.",
            ImageSource = "distros/debian.png",
            MemeDescription = "Ce meme montre une scène de Bob l'éponge où les utilisateurs de Debian Sid (la version instable de Debian) sont comparés à une vague déferlante, tandis que les utilisateurs de Debian et Fedora profitent tranquillement des dernières fonctionnalités. Cela illustre l'idée que les utilisateurs de Sid sont prêts à affronter les bugs et les instabilités pour avoir accès aux dernières mises à jour, contrairement aux utilisateurs de versions plus stables.",
            MemeSource = "distros/memes/debian_meme.jpeg"
        });

        _database.Insert(new Distro()
        {
            Name = "Arch Linux",
            Family = "Indépendante",
            ReleaseYear = 2002,
            Description = "La distro pour ceux qui aiment souffrir… mais avec style. Arch Linux, c’est comme monter un meuble IKEA sans notice : si tu réussis, tu es fier ; si tu échoues, tu pleures dans ton coin. Avec son Wiki légendaire et sa philosophie « fais-le toi-même », c’est la distro préférée des geeks qui aiment se vanter d’avoir « tout configuré à la main ». Spoiler : ils mentent.",
            ImageSource = "distros/arch.png",
            MemeDescription = "Ce meme utilise plusieurs scènes humoristiques pour représenter les utilisateurs d'Arch Linux comme des personnes qui se considèrent supérieures. Les images montrent des utilisateurs d'Arch recevant des médailles, célébrant leurs réussites, ou se moquant des autres distributions. Cela joue sur le stéréotype selon lequel les utilisateurs d'Arch Linux sont fiers de leur maîtrise technique et aiment souligner la difficulté de leur distribution, souvent perçue comme réservée aux experts.",
            MemeSource = "distros/memes/arch_meme.jpg"
        });

        _database.Insert(new Distro()
        {
            Name = "openSUSE",
            Family = "Indépendante",
            ReleaseYear = 2005,
            Description = "La distro pour les fans de vert et de configuration graphique. openSUSE, c’est comme un couteau suisse allemand : précis, bien organisé, et un peu rigide. Avec YaST, tu peux tout configurer sans toucher une ligne de commande… mais bon, où est le fun dans tout ça ? Idéal pour ceux qui aiment les distros stables et les logos en forme de caméléon.",
            ImageSource = "distros/opensuse.png",
            MemeDescription = "Ce meme montre un scientifique tenant un tube à essai étiqueté \"SUSE\" avec un autocollant \"Closed\" dessiné dessus, et la légende \"Finally ClosedSUSE\". Cela fait référence à la transition de openSUSE vers SUSE Linux Enterprise (SLE), souvent perçue comme plus fermée et commerciale. Le meme souligne la déception de certains utilisateurs face à cette orientation moins \"open source\".",
            MemeSource = "distros/memes/opensuse_meme.jpg"
        });

        _database.Insert(new Distro()
        {
            Name = "CentOS",
            Family = "Red Hat",
            ReleaseYear = 2004,
            Description = "Le Red Hat pour les radins (ou les entreprises). CentOS, c’était comme avoir une Rolls-Royce sans le logo… jusqu’à ce que Red Hat décide de tout changer. Maintenant, c’est un peu le chaos, mais les puristes gardent un œil nostalgique sur cette distro qui a fait tourner des milliers de serveurs. RIP, vieux pot.",
            ImageSource = "distros/centos.png",
            MemeDescription = "Ce meme utilise une image de \"Bad Luck Brian\" pour montrer la déception de quelqu'un passant de Windows à Linux et atterrissant sur CentOS. Le mot \"CentOS\" est utilisé ici pour évoquer une blague récurrente dans la communauté Linux, car CentOS a connu des changements majeurs (comme l'arrêt de CentOS 8), ce qui a pu décevoir certains utilisateurs cherchant une alternative stable à Windows.",
            MemeSource = "distros/memes/centos_meme.jpg"
        });

        _database.Insert(new Distro()
        {
            Name = "Mint",
            Family = "Ubuntu/Debian",
            ReleaseYear = 2006,
            Description = "Ubuntu, mais en mieux (et en plus vert). Mint, c’est comme passer de Windows XP à Windows 7 : tu gardes tes repères, mais tout est plus joli et plus fluide. Avec son bureau Cinnamon, c’est la distro idéale pour ceux qui veulent un Linux « qui marche » sans se prendre la tête. Parfait pour les réfractaires à Unity ou GNOME.",
            ImageSource = "distros/mint.png",
            MemeDescription = "Ce meme utilise une courbe de distribution normale pour représenter les utilisateurs de Linux. À gauche, un personnage avec un faible score d'IQ symbolise ceux qui recommandent Linux Mint pour sa simplicité. À droite, un personnage avec un score d'IQ élevé, habillé en moine, représente ceux qui insistent pour utiliser des distributions plus complexes comme Gentoo, Arch Linux, ou Linux From Scratch (LFS). Cela joue sur le stéréotype que les utilisateurs de ces distributions se considèrent comme plus expérimentés ou \"élitistes\".",
            MemeSource = "distros/memes/mint_meme.jpg"
        });

        _database.Insert(new Distro()
        {
            Name = "Manjaro",
            Family = "Arch Linux",
            ReleaseYear = 2011,
            Description = "Arch Linux, mais pour ceux qui ont une vie sociale. Manjaro, c’est comme avoir un Arch tout prêt, avec des paquets pré-compilés et un sourire en prime. Tu veux la puissance d’Arch sans passer trois jours à configurer ton Wi-Fi ? C’est ton jour de chance. Par contre, ne dis jamais à un vrai Archiste que tu utilises Manjaro. Ils te jugeront.",
            ImageSource = "distros/manjaro.png",
            MemeDescription = "Ce meme utilise une comparaison entre une personne souriante portant un t-shirt \"Linux is free... if your time has no value\" et un personnage sombre et menaçant étiqueté \"Linux Users\". La légende \"I trusted you. And you betrayed me.\" fait référence à la déception de certains utilisateurs de Manjaro, une distribution autrefois très appréciée pour sa simplicité et son accessibilité, mais qui a connu des controverses (comme des problèmes de gouvernance ou des mises à jour problématiques), trahissant ainsi la confiance de ses utilisateurs.",
            MemeSource = "distros/memes/manjaro_meme.png"
        });

        _database.Insert(new Distro()
        {
            Name = "Kali Linux",
            Family = "Debian",
            ReleaseYear = 2013,
            Description = "La distro pour ceux qui veulent se sentir comme dans « Mr. Robot »… sans forcément savoir ce qu’ils font. Kali Linux, c’est comme un couteau de survie : ultra-puissant, mais dangereux entre de mauvaises mains. Si tu l’installes juste pour « tester », prépare-toi à te faire bannir de ton propre réseau. Utilise-la à bon escient… ou pas.",
            ImageSource = "distros/kali.png",
            MemeDescription = "Ce meme montre un personnage qui semble intimidé par un dragon étiqueté \"Kali Linux\", avec la légende \"C'mon, do something...\". Cela illustre l'idée que les débutants installent Kali Linux, une distribution spécialisée dans la sécurité et le pentesting, en pensant devenir des hackers, mais se retrouvent souvent perdus et démunis face à sa complexité et ses outils avancés.",
            MemeSource = "distros/memes/kali_meme.jpg"
        });

        _database.Insert(new Distro()
        {
            Name = "Elementary OS",
            Family = "Ubuntu",
            ReleaseYear = 2011,
            Description = "Le Linux pour les fans de design et de minimalisme. Elementary OS, c’est comme un MacBook… mais en open source et sans le prix exorbitant. Si tu veux un système beau, épuré et simple, c’est ton choix. Par contre, prépare-toi à entendre « Mais c’est juste Ubuntu avec un thème ! » au moins une fois par jour. Spoiler : c’est (un peu) vrai.",
            ImageSource = "distros/elementary.png"
        });

        _database.Insert(new Database()
        {
            Name = "SQLite",
            Creator = "D. Richard Hipp",
            ReleaseYear = 2000,
            Description = "La base de données pour les minimalistes et les paresseux. SQLite, c’est comme un carnet de notes : léger, sans serveur, et il rentre dans ta poche. Tu veux stocker des données sans te prendre la tête ? SQLite est là. Il tourne partout, même sur ta machine à laver (bon, peut-être pas). Le seul inconvénient ? Si tu veux faire du multi-utilisateur, il te regardera avec mépris.",
            ImageSource = "databases/sqlite.png",
            MemeDescription = "Ce meme utilise Winnie l'ourson pour illustrer les différences de perception entre trois bases de données. SQLite est représenté avec une expression neutre, reflétant sa simplicité et son utilisation locale légère. MySQL, en costume élégant, symbolise une solution plus robuste et professionnelle, souvent utilisée pour des applications web. Enfin, Remote SQLite est montré avec une expression de panique, soulignant l’absurdité et les difficultés potentielles d’utiliser SQLite à distance, alors qu’il est conçu pour des usages locaux.",
            MemeSource = "databases/memes/sqlite_meme.jpg"
        });

        _database.Insert(new Database()
        {
            Name = "PostgreSQL",
            Creator = "PostgreSQL Global Development Group",
            ReleaseYear = 1996,
            Description = "Le couteau suisse des bases de données relationnelles. PostgreSQL, c’est comme un restaurant étoilé : tu peux y faire des requêtes SQL basiques, mais aussi des trucs si avancés que même les développeurs ne comprennent pas. Extensible, robuste, et open source, c’est la base de données préférée des puristes… et de ceux qui aiment se sentir supérieurs aux utilisateurs de MySQL.",
            ImageSource = "databases/postgres.png",
            MemeDescription = "Ce meme utilise une courbe de distribution normale pour montrer que, malgré les besoins spécifiques des applications d'IA à grande échelle (qui nécessiteraient des bases de données vectorielles spécialisées comme Pinecone), beaucoup de développeurs se contentent d'utiliser PostgreSQL pour tout. Les personnages aux extrémités de la courbe, qui conseillent simplement d'utiliser PostgreSQL, reflètent cette tendance à privilégier une solution polyvalente et bien maîtrisée, même quand elle n'est pas optimale.",
            MemeSource = "databases/memes/postgres_meme.webp"
        });

        _database.Insert(new Database()
        {
            Name = "MySQL",
            Creator = "Oracle Corporation",
            ReleaseYear = 1995,
            Description = "La base de données que tout le monde utilise… jusqu’à ce qu’elle plante. MySQL, c’est comme un vieux Toyota : ça roule, c’est partout, mais des fois tu te demandes si tu ne devrais pas passer à autre chose. Rachétée par Oracle, elle est devenue un peu plus chère et un peu moins aimée, mais elle reste la reine des sites web basiques. Et n’oublions pas les fameuses erreurs de syntaxe qui te font regretter ta carrière.",
            ImageSource = "databases/mysql.png",
            MemeDescription = "Ce meme montre deux personnages de dessins animés pour représenter MySQL et une version fictive appelée \"OurSQL\". MySQL est associé au drapeau américain, symbolisant son utilisation large et standardisée, tandis qu'\"OurSQL\" est associé à un symbole soviétique, suggérant une version alternative, moins connue ou plus restrictive. Cela peut évoquer les débats autour des bases de données open-source et leurs dérivés.",
            MemeSource = "databases/memes/mysql_meme.jpg"
        });

        _database.Insert(new Database()
        {
            Name = "MongoDB",
            Creator = "MongoDB Inc.",
            ReleaseYear = 2009,
            Description = "La base de données pour ceux qui détestent les schémas (et les jointures). MongoDB, c’est comme un placard où tu balances tout en vrac : c’est flexible, c’est rapide, et tu peux stocker n’importe quoi… jusqu’à ce que tu réalises que tu ne sais plus où est ton pull rouge. Les fans du NoSQL l’adorent, les autres râlent quand ils doivent faire des requêtes complexes. Et n’oublie pas : si tu ne shardes pas correctement, tu vas pleurer.",
            ImageSource = "databases/mongo.png",
            MemeDescription = "Ce meme utilise une scène des Simpson pour jouer sur le jeu de mots autour de MongoDB, une base de données NoSQL. Quand quelqu’un demande une \"table\" (comme dans les bases de données relationnelles), MongoDB répond qu’il n’y a pas de table, seulement des \"documents\". Cela souligne la différence fondamentale entre les bases de données relationnelles (qui utilisent des tables) et MongoDB (qui stocke les données sous forme de documents JSON).",
            MemeSource = "databases/memes/mongo_meme.jpg"
        });

        _database.Insert(new Database()
        {
            Name = "SQL Server",
            Creator = "Microsoft",
            ReleaseYear = 1989,
            Description = "La base de données pour ceux qui aiment payer (beaucoup). SQL Server, c’est comme un abonnement à la salle de sport : tu paies cher, mais au moins t’as accès à toutes les machines. Intégré à l’écosystème Microsoft, c’est le choix évident si tu veux faire plaisir à ton DSI… ou si tu aimes les licences qui coûtent un bras. Et bien sûr, il y a SSMS, l’outil qui te fait aimer et détester Microsoft en même temps.",
            ImageSource = "databases/sqlserver.png",
            MemeDescription = "Ce meme utilise une scène du film Scarface pour illustrer la progression dans l'utilisation de SQL Server Management Studio. La première image montre un utilisateur débutant, assis sur une balançoire, symbolisant une approche naïve et simple. Les deux images suivantes montrent une descente progressive dans la complexité et les défis, évoquant l'idée que gérer SQL Server peut devenir rapidement compliqué et stressant, comme une plongée dans un monde de plus en plus difficile.",
            MemeSource = "databases/memes/sqlserver_meme.jpg"
        });

        _database.Insert(new Database()
        {
            Name = "Oracle Database",
            Creator = "Oracle Corporation",
            ReleaseYear = 1979,
            Description = "La Rolls-Royce des bases de données… si tu peux te la payer. Oracle, c’est comme un costume sur mesure : ultra-performant, ultra-cher, et ultra-compliqué à configurer. Les grandes entreprises l’adorent, les petits budgets fuient en hurlant. Et n’oublie pas : chaque fois que tu l’utilises, Larry Ellison achète une nouvelle île.",
            ImageSource = "databases/oracle.png",
            MemeDescription = "Ce meme utilise des images humoristiques pour représenter les outils de survie nécessaires pour travailler avec Oracle SQL. Le pack inclut du Lemon Balm (pour se calmer), de la vodka (pour supporter le stress), et une image de quelqu’un en crise existentielle. Cela reflète la réputation d’Oracle SQL pour sa complexité et sa difficulté d’utilisation, souvent perçue comme frustrante par les développeurs.",
            MemeSource = "databases/memes/oracle_meme.png"
        });

        _database.Insert(new Database()
        {
            Name = "Redis",
            Creator = "Salvatore Sanfilippo",
            ReleaseYear = 2009,
            Description = "La base de données pour ceux qui veulent que tout aille très, très vite. Redis, c’est comme une Ferrari : tu stockes tes données en mémoire, et tout devient instantané… jusqu’à ce que tu redémarres ton serveur et que tout disparaisse. Parfait pour le cache, les sessions, et les devs qui aiment vivre dangereusement. Et bien sûr, tout le monde adore ses commandes qui ressemblent à de l’anglais approximatif.",
            ImageSource = "databases/redis.png",
            MemeDescription = "Ce meme utilise une scène d'anime pour représenter la confusion autour de Redis. Le personnage, avec un air interrogateur, demande \"Is this a database?\" (\"Est-ce que c'est une base de données ?\"). Cela reflète la nature particulière de Redis, qui est souvent utilisé comme un magasin clé-valeur en mémoire, un cache, ou même une base de données, brouillant les frontières traditionnelles entre ces concepts pour les développeurs et les startups qui l'utilisent de manière flexible.",
            MemeSource = "databases/memes/redis_meme.png"
        });

        _database.Insert(new Database()
        {
            Name = "MariaDB",
            Creator = "Michael Widenius",
            ReleaseYear = 2009,
            Description = "MySQL, mais en mieux et sans Oracle. MariaDB, c’est comme un clone amélioré : compatible, open source, et sans les travers commerciaux de son grand frère. Si tu veux une base de données relationnelle sans te prendre la tête (ni le portefeuille), c’est un excellent choix. Et en plus, tu peux te sentir vertueux en soutenant l’open source. Win-win !",
            ImageSource = "databases/mariadb.png",
            MemeDescription = "Ce meme utilise une réaction de Drake pour comparer MariaDB, une base de données respectée et largement adoptée (représentée par un \"j'aime\"), et JosefDB, une référence humoristique à une base de données fictive et peu connue (représentée par un \"je n'aime pas\"). Cela joue sur la popularité et la fiabilité de MariaDB, souvent préférée pour sa compatibilité avec MySQL et sa communauté active, par opposition à des solutions obscures ou non éprouvées.",
            MemeSource = "databases/memes/mariadb_meme.jpg"
        });

        _database.Insert(new Database()
        {
            Name = "Cassandra",
            Creator = "Apache Software Foundation",
            ReleaseYear = 2008,
            Description = "La base de données pour ceux qui veulent scalabilité et complexité. Cassandra, c’est comme un puzzle en 3D : ultra-performante pour les gros volumes de données, mais bon courage pour comprendre comment tout s’assemble. Utilisée par les géants du web, elle te promet de ne jamais tomber en panne… à condition de savoir configurer tes nœuds. Spoiler : tu ne sais pas.",
            ImageSource = "databases/cassandra.png",
            MemeDescription = "Ce meme utilise une réaction de choc pour illustrer la prise de conscience que Cassandra, bien que portant un prénom féminin, n’est pas une personne mais une base de données distribuée conçue par Apache. Le nom fait référence à la prêtresse Cassandre de la mythologie grecque, mais le meme joue sur la surprise de ceux qui pourraient s’attendre à autre chose.",
            MemeSource = "databases/memes/cassandra_meme.jpg"
        });

        _database.Insert(new Database()
        {
            Name = "Firebase Realtime Database",
            Creator = "Google",
            ReleaseYear = 2016,
            Description = "La base de données pour les devs mobiles pressés (et un peu fainéants). Firebase, c’est comme un drive-through : tu pushes tes données, et tout est synchronisé en temps réel. Parfait pour les petites apps et les prototypes, un peu moins pour les gros projets où tu réalises que tu viens de donner toutes tes données à Google. Mais bon, qui lit les CGU de toute façon ?",
            ImageSource = "databases/firebase.png",
            MemeDescription = "Ce meme montre deux réactions contrastées de Google : une réaction de panique quand quelqu’un utilise plus de 10 Go sur leur base de données, et une réaction détendue quand quelqu’un upload une vidéo de 40 Go sur YouTube. Cela critique avec humour les limites arbitraires imposées par Google sur certains services, tout en permettant des usages bien plus lourds sur d’autres plateformes.",
            MemeSource = "databases/memes/firebase_meme.png"
        });
    }
    
    public List<Language> GetLanguages()
    {
        return _database.GetAllWithChildren<Language>()
            .OrderBy(x => x.Name)
            .ToList();
    }
    
    public List<Distro> GetDistros()
    {
        return _database.GetAllWithChildren<Distro>()
            .OrderBy(x => x.Name)
            .ToList();
    }
    
    public List<Database> GetDatabases()
    {
        return _database.GetAllWithChildren<Database>()
            .OrderBy(x => x.Name)
            .ToList();
    }
}
