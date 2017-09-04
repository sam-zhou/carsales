﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Carsales.Common.Extension
{
    public static class DynamicClassHelper
    {
        public static Assembly CreateDynamicAssembly(string nameSpace, IEnumerable<DynamicTypeInfo> types)
        {
            BuildTypes(nameSpace, types);
            return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(q => q.GetName().Name == nameSpace);
            //var constructor = typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

            //// NOTE: assuming your list contains Field objects with fields FieldName(string) and FieldType(Type)
            //foreach (var field in fields)
            //{
            //    CreateProperty(typeBuilder, field);
            //}


            //Type objectType = typeBuilder.CreateType();
            //return objectType;
        }

        private static void BuildTypes(string nameSpace, IEnumerable<DynamicTypeInfo> types)
        {
            var assemblyName = new AssemblyName(nameSpace);
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            foreach (var type in types)
            {
                var moduleBuilder = assemblyBuilder.DefineDynamicModule(type.Name);
                var typeBuilder = moduleBuilder.DefineType(type.Name
                                    , TypeAttributes.Public |
                                    TypeAttributes.Class |
                                    TypeAttributes.AutoClass |
                                    TypeAttributes.AnsiClass |
                                    TypeAttributes.BeforeFieldInit |
                                    TypeAttributes.AutoLayout
                                    , type.Parent);
                typeBuilder.CreateType();
            }
            
        }

        private static void CreateProperty(TypeBuilder typeBuilder, FieldInfo filedInfo)
        {
            var fieldBuilder = typeBuilder.DefineField("_" + filedInfo.Name, filedInfo.FieldType, FieldAttributes.Private);

            var propertyBuilder = typeBuilder.DefineProperty(filedInfo.Name, PropertyAttributes.HasDefault, filedInfo.FieldType, null);
            var getPropMthdBldr = typeBuilder.DefineMethod("get_" + filedInfo.Name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, filedInfo.FieldType, Type.EmptyTypes);
            var getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            var setPropMthdBldr =
                typeBuilder.DefineMethod("set_" + filedInfo.Name,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { filedInfo.FieldType });

            var setIl = setPropMthdBldr.GetILGenerator();
            var modifyProperty = setIl.DefineLabel();
            var exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }
    }
}
