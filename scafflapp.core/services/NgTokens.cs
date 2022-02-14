using System.Collections.Generic;
using System.Text;
using scafflapp.core.models;

namespace scafflapp.core.services
{
    public class NgTokens
    {

        private static string _formCtrlDefs = string.Empty;
        private static string _initFormCtrls = string.Empty;
        private static string _mapFormCtrls = string.Empty;
        private static string _formCtrlValue = string.Empty;
        private static string _mapORMValue = string.Empty;
        private static string _tsInterfaceDefs = string.Empty;
        public static void Append(IDictionary<string, string> tokens, List<EntityProperty> entityProperties)
        {
            BuildFeildControls(entityProperties);
            tokens.Add("~!form-control-defs!~", _formCtrlDefs);
            tokens.Add("~!init-form-controls!~", _initFormCtrls);
            tokens.Add("~!map-form-controls!~", _mapFormCtrls);
            tokens.Add("~!map-control-values!~", _formCtrlValue);
            tokens.Add("~!map-orm-values!~", _mapORMValue);
            tokens.Add("~!ts-interface-def!~", _tsInterfaceDefs);
        }

        private static void BuildFeildControls(List<EntityProperty> columnDefs)
        {
            string result = string.Empty;
            StringBuilder formCtrlDefs = new StringBuilder();
            List<string> initFormCtrls = new List<string>();
            StringBuilder mapFormCtrls = new StringBuilder();
            StringBuilder formCtrlValue = new StringBuilder();
            StringBuilder mapORMValue = new StringBuilder();
            List<string> tsInterfaceDefs = new List<string>();

            var typeMaps = new TypeMaps();

            foreach (var columnDef in columnDefs)
            {
                var camelCase = columnDef.Name.ToCamelCase();
                formCtrlDefs.AppendLine($"{camelCase}Field: FormControl = new FormControl({{ value: null, disabled: false }}{BuildValidators(columnDef)} );");
                initFormCtrls.Add($" {camelCase}Field: this.{camelCase}Field");
                mapFormCtrls.AppendLine($"this.{camelCase}Field.setValue(this.model.{camelCase});");
                formCtrlValue.AppendLine($"this.model.{camelCase}=this.{camelCase}Field.value;");
                mapORMValue.AppendLine($"this.model.{camelCase}=this.{camelCase}Field.value;");
                tsInterfaceDefs.Add($"{camelCase} : {typeMaps[columnDef.Type].JType}");
            }

            _formCtrlDefs = formCtrlDefs.ToString();
            _initFormCtrls = string.Join(",\n", initFormCtrls);
            _mapFormCtrls = mapFormCtrls.ToString();
            _formCtrlValue = formCtrlValue.ToString();
            _tsInterfaceDefs = string.Join(",\n", tsInterfaceDefs);
        }

        private static string BuildValidators(EntityProperty column)
        {
            List<string> validators = new List<string>();

            if (column.IsNull)
                validators.Add("Validators.required");
            if (column.Type == "DECIMAL")
                validators.Add("Validators.min(0.01), Validators.max(99999.99)");

            return validators.Count > 0 ?
                $", [{string.Join(',', validators)}]" :
                string.Empty;
        }

    }
}