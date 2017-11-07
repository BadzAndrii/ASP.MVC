using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2Server.Models
{
    public class ListSageModels : SageModel
    {
        public ListSageModels ()
        {
            Sages = new List<SageModel>(0);
        }
        // PRE- !!!VIEW!!!
        public List<SageModel> Sages { get; private set; }
    }
}