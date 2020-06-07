using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ETModel_SkillData_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ETModel.SkillData);

            field = type.GetField("skillInputType", flag);
            app.RegisterCLRFieldGetter(field, get_skillInputType_0);
            app.RegisterCLRFieldSetter(field, set_skillInputType_0);
            field = type.GetField("id", flag);
            app.RegisterCLRFieldGetter(field, get_id_1);
            app.RegisterCLRFieldSetter(field, set_id_1);


        }



        static object get_skillInputType_0(ref object o)
        {
            return ((ETModel.SkillData)o).skillInputType;
        }
        static void set_skillInputType_0(ref object o, object v)
        {
            ((ETModel.SkillData)o).skillInputType = (ETModel.SkillInputType)v;
        }
        static object get_id_1(ref object o)
        {
            return ((ETModel.SkillData)o).id;
        }
        static void set_id_1(ref object o, object v)
        {
            ((ETModel.SkillData)o).id = (System.Int64)v;
        }


    }
}
