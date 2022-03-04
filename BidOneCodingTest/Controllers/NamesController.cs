using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BidOneCodingTest.Models;
using Newtonsoft.Json;

namespace BidOneCodingTest.Controllers
{
    public class NamesController : Controller
    {
        List<NameModel> names = new List<NameModel>();
        //ReadAndWriteJsonFile holds the logic to extract the data from json file and also it has logic to update the data
        ReadAndWriteJsonFile readWrite = new ReadAndWriteJsonFile();
        public IActionResult Index()
        {
            //Deserializes json data into .net object
            names = JsonConvert.DeserializeObject<List<NameModel>>(readWrite.Read("Names.json", "data"));
            //send the object to view to display data from json file
            return View(names);
        }

        [HttpPost]
        public IActionResult AddName(NameModel nameModel)
        {
            //Deserializes json data into .net object
            names = JsonConvert.DeserializeObject<List<NameModel>>(readWrite.Read("Names.json", "data"));
            //assign the new id to add new records
            nameModel.id = names.Count + 1;
            NameModel name = names.FirstOrDefault(x => x.id == nameModel.id);
            if (name == null)
            {
                //add new records into the existing deserialised object "names"
                names.Add(nameModel);
            }
            else
            {
                int index = names.FindIndex(x => x.id == nameModel.id);
                names[index] = nameModel;
            }
            //Serialise the updated object data
            string jSONString = JsonConvert.SerializeObject(names);
            //send the data to ReadAndWriteJsonFile class which is based in "Models" folder
            readWrite.Write("Names.json", "data", jSONString);
            return this.Ok("Data is saved successfully!");
        }

    }
}
