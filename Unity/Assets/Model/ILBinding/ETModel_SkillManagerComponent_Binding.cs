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
    unsafe class ETModel_SkillManagerComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ETModel.SkillManagerComponent);
            args = new Type[]{typeof(System.Int64)};
            method = type.GetMethod("getSkillById", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, getSkillById_0);

            field = type.GetField("skillHolders", flag);
            app.RegisterCLRFieldGetter(field, get_skillHolders_0);
            app.RegisterCLRFieldSetter(field, set_skillHolders_0);


        }


        static StackObject* getSkillById_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int64 @id = *(long*)&ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ETModel.SkillManagerComponent instance_of_this_method = (ETModel.SkillManagerComponent)typeof(ETModel.SkillManagerComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.getSkillById(@id);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_skillHolders_0(ref object o)
        {
            return ((ETModel.SkillManagerComponent)o).skillHolders;
        }
        static void set_skillHolders_0(ref object o, object v)
        {
            ((ETModel.SkillManagerComponent)o).skillHolders = (System.Collections.Generic.List<ETModel.SkillHolder>)v;
        }


    }
}
