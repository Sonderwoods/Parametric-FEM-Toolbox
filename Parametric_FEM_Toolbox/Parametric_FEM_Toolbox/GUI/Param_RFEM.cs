using System;
using System.Collections.Generic;
using System.Drawing;
using Parametric_FEM_Toolbox.Properties;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;


namespace Parametric_FEM_Toolbox.GUI
{
    // Class to define the Grasshopper Parameter "Param_RFEM".
    // This is the output parameter that the RFEM Objects will use in Grasshopper.
    public class Param_RFEM : GH_PersistentParam<GH_Brep>
    {
        // We need to supply a constructor without arguments that calls the base class constructor.
        public Param_RFEM() :
        base("RF Object", "RF Object", "RFEM Object (Nodes, Lines, Supports, Loads...)", "B+G Toolbox", "RFEM")
        { }

        public override IEnumerable<string> Keywords => new string[] { "rf", "object" };

        // Always generate a new Guid, but never change it once
        // you've released this parameter to the public.
        public override Guid ComponentGuid => new Guid("{f12297be-474f-4145-a2be-41f51cf4e14e}");
        

          protected override GH_GetterResult Prompt_Plural(ref List<GH_Brep> values)
        {
            return GH_GetterResult.success;
        }

        protected override GH_GetterResult Prompt_Singular(ref GH_Brep value)
        {
            return GH_GetterResult.success;
        }

        public override GH_Exposure Exposure => GH_Exposure.primary;

        protected override Bitmap Icon => Resources.icon_RFEM_Param;

        protected override GH_Brep PreferredCast(object data)
        {
            return new GH_Brep();

            //if (data is IGH_GeometricGoo)
            //{
            //    return new GH_Brep((IGH_GeometricGoo)data);
            //}
            //else if (data is IGH_Goo)
            //{
            //    var rfGoo = data as GH_Goo<object>;
            //    return new GH_Brep((IGH_GeometricGoo)rfGoo.Value);
            //}
            //throw new Exception("Cast to IGrassRFEM impossible.");

        }

        
    }
}
