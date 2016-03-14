using rekrutacja_contact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactTest
{
    class TestContactDbSet :TestDbSet<Contact>
    {
        public override Contact Find(params object[] keyValues)
        {
            return this.SingleOrDefault(contact => contact.Id == (int)keyValues.Single());
        }
    
    }
    
}
