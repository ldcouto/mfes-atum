// <auto-generated>

// This file contains automatically generated unit tests.

// Do NOT modify this file manually.

// 

// When Pex is invoked again,

// it might remove or update any previously generated unit tests.

// 

// If the contents of this file becomes outdated, e.g. if it does not

// compile anymore, you may delete this file and invoke Pex again.

// </auto-generated>

using System;
using ATUM.sistema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Engine.Exceptions;
using ATUM.Tests.Pex.Factories;

namespace ATUM.Tests.Pex.sistema
{
    public partial class PreferenciaTests
    {
        [TestMethod]
        [PexGeneratedBy(typeof(PreferenciaTests))]
        [PexRaisedContractException(PexExceptionState.Expected)]
        public void ConstructorThrowsContractException89()
        {
            try
            {
                Preferencia preferencia;
                preferencia = this.Constructor(0u, (Bloco)null);
                throw new AssertFailedException();
            }
            catch(Exception ex)
            {
                if (!PexContract.IsContractException(ex))
                    throw ex;
            }
        }
        [TestMethod]
        [PexGeneratedBy(typeof(PreferenciaTests))]
        public void Constructor261()
        {
            Bloco bloco;
            Preferencia preferencia;
            bloco = BlocoFactory.Create((string)null, (Turno[])null);
            preferencia = this.Constructor(0u, bloco);
            Assert.IsNotNull((object)preferencia);
            Assert.AreEqual<uint>(0u, preferencia.Grau);
            Assert.IsNotNull(preferencia.Bloco);
            Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
            Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
        }
        [TestMethod]
        [PexGeneratedBy(typeof(PreferenciaTests))]
        public void Constructor26101()
        {
            Bloco bloco;
            Preferencia preferencia;
            Turno[] turnos = new Turno[0];
            bloco = BlocoFactory.Create((string)null, turnos);
            preferencia = this.Constructor(0u, bloco);
            Assert.IsNotNull((object)preferencia);
            Assert.AreEqual<uint>(0u, preferencia.Grau);
            Assert.IsNotNull(preferencia.Bloco);
            Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
            Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
        }
        [TestMethod]
        [PexGeneratedBy(typeof(PreferenciaTests))]
        public void Constructor26102()
        {
            Bloco bloco;
            Preferencia preferencia;
            Turno[] turnos = new Turno[1];
            bloco = BlocoFactory.Create((string)null, turnos);
            preferencia = this.Constructor(0u, bloco);
            Assert.IsNotNull((object)preferencia);
            Assert.AreEqual<uint>(0u, preferencia.Grau);
            Assert.IsNotNull(preferencia.Bloco);
            Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
            Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
        }
    }
}


