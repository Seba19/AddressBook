using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekrutacja_contact.Models
{
 public interface IDBContext: IDisposable
    {
        DbSet<Contact> Contacts { get; }
        int SaveChanges();
        void MarkAsModified(Contact item);    
    
    
    }
}
