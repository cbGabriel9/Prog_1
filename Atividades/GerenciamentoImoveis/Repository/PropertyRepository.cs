using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    public class PropertyRepository
    {
        public List<Property> RetrieveAll()
        {
            return PropertyData.Properties;
        }

        public Property Retrieve(int id)
        {
            foreach (Property p in PropertyData.Properties)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null!;
        }

    }
}
