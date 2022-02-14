using System.Collections.Generic;
using scafflapp.core.models;

namespace scafflapp.core.services
{
    public class TypeMaps : Dictionary<string, TypeMap>
    {
        public TypeMaps()
        {
               this.Add( "NVARCHAR", new TypeMap() { SourceType = "NVARCHAR",CType = "string",JType="string" });
               this.Add(  "VARCHAR",new TypeMap() { SourceType = "VARCHAR",CType = "string",JType="string" });
               this.Add(  "INTEGER",new TypeMap() { SourceType = "INTEGER",CType = "int",JType="number" });
               this.Add(  "NUMERIC",new TypeMap() { SourceType = "NUMERIC",CType = "decimal",JType="number" });
               this.Add(  "DATETIME",new TypeMap() { SourceType = "DATETIME",CType = "DateTime",JType="Date" });
               this.Add(  "BIT",new TypeMap() { SourceType = "BIT",  CType = "bool",JType="Boolean" });
        }
    }
}