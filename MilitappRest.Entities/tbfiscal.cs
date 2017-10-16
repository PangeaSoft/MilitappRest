using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MilitappRest.Entities
{
    [MetadataType(typeof(tbfiscal_Metadata))]
    public partial class tbfiscal
    {
    }
    //ANALIZAR PORQUE NO TOMA LOS METADATOS
    //[DataContract]
    //[Serializable]
    public class tbfiscal_Metadata
    {
        //[DataMember( EmitDefaultValue = false)]
        //public string fis_apellido { get; set; }
    }
}
