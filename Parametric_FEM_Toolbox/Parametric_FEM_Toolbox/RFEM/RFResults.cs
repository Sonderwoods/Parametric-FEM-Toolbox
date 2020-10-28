﻿using System;
using Dlubal.RFEM5;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using Parametric_FEM_Toolbox.Utilities;
using Parametric_FEM_Toolbox.HelperLibraries;
using System.Collections.Generic;
using System.Linq;

namespace Parametric_FEM_Toolbox.RFEM
{
    [Serializable]
    public class RFResults : IGrassRFEM
    {
        //Standard constructors
        public RFResults()
        {
        }
        public RFResults(IResults results, IModelData data, LoadingType loadingType, int loadNo) // rfem object as array because they are related to the same member
        {
            LoadingType = loadingType;
            LoadNo = loadNo;
            MemberForces = GetRFMemberForces(results, data);
            ToModify = false;
            ToDelete = false;
        }

        public List<RFMemberForces> GetRFMemberForces(IResults results, IModelData data)
        {
            var myForces = new List<RFMemberForces>();
            foreach (var member in data.GetMembers())
            {
                if (member.Type == MemberType.NullMember)
                {
                    continue;
                }
                var forces = results.GetMemberInternalForces(member.No, ItemAt.AtNo, true);
                myForces.Add(new RFMemberForces(forces));
            }
            return myForces;
        }


        //public RFMemberForces(RFMemberForces other) : this(other)
        //{

        //    //if (other.BaseLine != null)
        //    //{
        //    //    BaseLine = new RFLine(other.BaseLine);
        //    //}            
        //    //Frames = other.Frames;
        //}

        // Properties to Wrap Fields from RFEM Struct
        public LoadingType LoadingType { get; set; }
        public int LoadNo { get; set; }

        public List<RFMemberForces> MemberForces { get; set; }
        //public int CrossSectionNo { get; set; } // makes no sense?

        // Additional Properties to the RFEM Struct
        public bool ToModify { get; set; }
        public bool ToDelete { get; set; }
        //public int NewNo { get; set; }

        // Display Info of the RFEM Objects on Panels
        // Parameters are separated by ";". The component split text can be used to break the string down into a list.
        public override string ToString()
        {
            return string.Format($"RFEM-Results:{LoadingType} {LoadNo}");
        }

        ////Operator to retrieve a Line from an rfLine.
        //public static implicit operator MemberForces(RFMemberForces member_forces)
        //{
        //    Dlubal.RFEM5.MemberForces myForces = new Dlubal.RFEM5.MemberForces

            
        //    return myForces;
        //}

        // Convert RFEM Object into Rhino Geometry.
        // These methods are later implemented by the class GH_RFEM.
        public bool ToGH_Integer<T>(ref T target)
        {
            return false;
        }
        public bool ToGH_Point<T>(ref T target)
        {
            return false;
        }
        public bool ToGH_Line<T>(ref T target)
        {
            return false;
        }
        public bool ToGH_Curve<T>(ref T target)
        {
            return false;
        }
        public bool ToGH_Surface<T>(ref T target)
        {
            return false;
        }
        public bool ToGH_Brep<T>(ref T target)
        {
            return false;
        }
        public bool ToGH_Plane<T>(ref T target)
        {
            return false;
        }
    }
}