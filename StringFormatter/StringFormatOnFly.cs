using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace StringFormatter
{
    public class StringFormatOnFly
    {
        private const string fileName = @"E:\study\code\c#\StringGenerator\StringGenerator\StringFormatter\StringFormatOnFlyTemplate.txt";
        private const string nameSpace = "StringFormatter";
        private const string className = "StringFormatOnFlyTemplate";
        private const string functionName = "ConvertStrOnFly";

        private List<string> refAssembliesList = new List<string>
                                                     {
                                                         "System.Xml.Linq.dll",
                                                         "System.dll",
                                                         "System.Data.dll",
                                                         "System.XML.dll",
                                                         "System.Core.dll"
                                                     };
        public object ExecuteOnFlyCode(string functionStr, string inputStr)
        {
            StreamReader sr = new StreamReader(fileName);
            var templateStr = sr.ReadToEnd();
            var strToExecute = templateStr.Replace("{0}", functionStr);
            var ret = ExecuteCode(strToExecute, nameSpace, className, functionName, true, inputStr);
            return ret;
        }
        private Assembly BuildAssembly(string code)
        {
            Microsoft.CSharp.CSharpCodeProvider provider = 
                   new CSharpCodeProvider();
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters compilerparams = new CompilerParameters();
            compilerparams.GenerateExecutable = false;
            compilerparams.GenerateInMemory = true;
            foreach (var refAss in refAssembliesList)
            {
                 compilerparams.ReferencedAssemblies.Add(refAss);
            }
           
            
            CompilerResults results = 
           compiler.CompileAssemblyFromSource(compilerparams, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                foreach (CompilerError error in results.Errors)
                {
                    errors.AppendFormat("Line {0},{1}\t: {2}\n",
                           error.Line, error.Column, error.ErrorText);
                }
                throw new Exception(errors.ToString());
            }
            else
            {
                return results.CompiledAssembly;
            }
        }
        private object ExecuteCode(string code,
            string namespacename, string classname,
            string functionname, bool isstatic, params object[] args)
        {
            object returnval = null;
            Assembly asm = BuildAssembly(code);
            object instance = null;
            Type type = null;
            if (isstatic)
            {
                type = asm.GetType(namespacename + "." + classname);
            }
            else
            {
                instance = asm.CreateInstance(namespacename + "." + classname);
                type = instance.GetType();
            }
            MethodInfo method = type.GetMethod(functionname);
            returnval = method.Invoke(instance, args);
            return returnval;
        }
    }
}
