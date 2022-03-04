using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BidOneCodingTest.Models
{
    public class ReadAndWriteJsonFile
    {
        public ReadAndWriteJsonFile() { }
        public string Read(string fileName, string location)
        {
            string root = "wwwroot";
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                root,
                location,
                fileName
                );
            string jsonResult;
            using (StreamReader streamReader = new StreamReader(path))
            {
                //Read whole json file data
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public void Write(string fileName, string location, string jSONString)
        {
            string root = "wwwroot";
            var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            root,//root is "wwwroot" folder
            location,//location of folder data where Names.json file is there
            fileName);//filename is Names.json

            using (var streamWriter = File.CreateText(path))
            {
                //write the new data into Names.json file
                streamWriter.Write(jSONString);
            }
        }
    }
}
