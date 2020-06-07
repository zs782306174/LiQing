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
    unsafe class ETModel_UserInputComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ETModel.UserInputComponent);
            args = new Type[]{};
            method = type.GetMethod("get_Instance", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Instance_0);
            args = new Type[]{};
            method = type.GetMethod("get_SelectUnit", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_SelectUnit_1);

            field = type.GetField("keyBoardDown", flag);
            app.RegisterCLRFieldGetter(field, get_keyBoardDown_0);
            app.RegisterCLRFieldSetter(field, set_keyBoardDown_0);
            field = type.GetField("points", flag);
            app.RegisterCLRFieldGetter(field, get_points_1);
            app.RegisterCLRFieldSetter(field, set_points_1);
            field = type.GetField("keyBoardUp", flag);
            app.RegisterCLRFieldGetter(field, get_keyBoardUp_2);
            app.RegisterCLRFieldSetter(field, set_keyBoardUp_2);


        }


        static StackObject* get_Instance_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ETModel.UserInputComponent.Instance;

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_SelectUnit_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ETModel.UserInputComponent instance_of_this_method = (ETModel.UserInputComponent)typeof(ETModel.UserInputComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.SelectUnit;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_keyBoardDown_0(ref object o)
        {
            return ((ETModel.UserInputComponent)o).keyBoardDown;
        }
        static void set_keyBoardDown_0(ref object o, object v)
        {
            ((ETModel.UserInputComponent)o).keyBoardDown = (System.Collections.Generic.Dictionary<UnityEngine.KeyCode, System.Boolean>)v;
        }
        static object get_points_1(ref object o)
        {
            return ((ETModel.UserInputComponent)o).points;
        }
        static void set_points_1(ref object o, object v)
        {
            ((ETModel.UserInputComponent)o).points = (System.Collections.Generic.List<UnityEngine.Vector3>)v;
        }
        static object get_keyBoardUp_2(ref object o)
        {
            return ((ETModel.UserInputComponent)o).keyBoardUp;
        }
        static void set_keyBoardUp_2(ref object o, object v)
        {
            ((ETModel.UserInputComponent)o).keyBoardUp = (System.Collections.Generic.Dictionary<UnityEngine.KeyCode, System.Boolean>)v;
        }


    }
}
