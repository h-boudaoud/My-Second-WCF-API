# My-Second-WCF-API
Création d'un web service Web en utilisant WCF, Entity framwork, et un clien web

ce projet à été réalisé pour obtenir le rendu du chapitre : [Web service SOAP avec WCF et LINQ](https://www.dotmyself.net/doc/10.html)

## Service WCF
#### Ouvrir le Dossier WCF-Service/App_Data/ du projet puis executer le script SQL dans SQL SERVER.

#### Dans My-Second-WCF-API/WCF-Service/Web.config

50  < connectionStrings >

51     < add name="EFContexte" connectionString="data source=.\SQLEXPRESS;initial catalog=Banking;persist security info=True;user id=sa;password=******;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />

52  </ connectionStrings>
  
Selon l'installation du SQL Server sur la machine, modifier dans la ligne 51 les valeurs de 
 - source = nom du host
 - catalog = nom de Database
 id = identifiant pour se connecter à SQL Server
 password = mot de passe du SQL Server
 
 
#### Déployer le service WCF sur IIS (voir [Déployez votre service WCF sur IIS](https://openclassrooms.com/fr/courses/2974101-creez-votre-premiere-application-connectee-en-c-net/2989701-deployez-votre-service-wcf-sur-iis))

## Application Client

#### Définir ConsoleApp comme application par défaut 

 #### Dans My-Second-WCF-API/ConsoleApp/App.config
 
 < client>
      < endpoint address="adresse du service WCF sur la machine"  />
 </ client>
 
 Modifier l'attribue address en renseignant votre adresse du WCf déployé sur votre machine. 
 
 
