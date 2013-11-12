
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;

namespace Dynamic.Ampla.AmplaData2008.Binding
{
    public class AmplaGetDataBinding : IAmplaBinding
    {
        //private readonly IModelProperties<TModel> modelProperties;
        private readonly GetDataResponse response;
        private readonly List<dynamic> records;

        public AmplaGetDataBinding(GetDataResponse response, List<dynamic> records) //IModelProperties<TModel> modelProperties)
        {
           // this.modelProperties = modelProperties;
            this.response = response;
            this.records = records;
        }

        public bool Bind()
        {
            if (response.RowSets.Length == 0) return false;

            RowSet rowSet = response.RowSets[0];

            //string idPropertyName = ModelIdentifier.GetPropertyName<TModel>();

            foreach (Row row in rowSet.Rows)
            {
                dynamic record = new ExpandoObject();
                IDictionary<string, object> dictionary = record;
                dictionary.Add("Id", int.Parse(row.id));
                //modelProperties.TrySetValueFromString(model, idPropertyName, row.id);

                foreach (XmlElement cell in row.Any)
                {
                    string field = XmlConvert.DecodeName(cell.Name);
                    dictionary.Add(field, cell.InnerText);
                    //modelProperties.TrySetValueFromString(model, field, cell.InnerText);
                }
                records.Add(record);
            }
            return true;
        }

        public bool Validate()
        {
            return true;
        }
    }
}