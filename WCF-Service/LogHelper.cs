using System;
using System.IO;

namespace WCF_Service
{
    internal class LogHelper
    {
        internal static void WriteToFile(string errorMessage, string message)
        {
            DateTime nowDate = DateTime.Now;
            string shortDate = String.Format("{0:yyyy-MM-dd}", nowDate);
            string filename = string.Format("{0}.log", shortDate);
            //création du nom de fichier .log
            filename = filename.Replace("/", "-");
            //récupérer le path complet, application PC
            string rootPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            //string rootPath = Path.GetFullPath("C:/Git/SOAP-WCF-Solution/SOAP-WCF-Solution/WCF-Service/Log/");
            rootPath += "Log/";
            //ou le path pour une application serveur
            //System.Web.HttpContext.Current.Server.MapPath("~/Log/");
            string fullFilename = string.Format(@"{0}{1}", rootPath, filename);
            //vérifier les dossiers Data & Log
            if (!Directory.Exists(rootPath))
            {
                //création du dossier
                Directory.CreateDirectory(rootPath);
            }
            //vérifier le fichier
            if (!System.IO.File.Exists(fullFilename))
            {
                //création du fichier log du jour
                System.IO.FileStream f = System.IO.File.Create(fullFilename);
                f.Close();
            }

            using (StreamWriter writer = new StreamWriter(fullFilename, true))
            {
                //écriture dans le fichier log du jour
                writer.WriteLine(string.Format(
                                       "[{0} ON {1}] :\n\t {2}",
                                       DateTime.Now,
                                       message,
                                       errorMessage));
            }
        }
    }
}