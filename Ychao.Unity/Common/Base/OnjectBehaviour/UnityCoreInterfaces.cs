using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ychao.Unity
{
    public interface IMonoActive : IActive, IMonoBinds
    {
    }

    public interface IMonoInactive : IInactive, IMonoBinds
    {
    }

    public interface IMonoReset : IReset
    {
    }

    public interface IMonoInitialize : IInitialize, IMonoBinds
    {
    }

    public interface IMonoAwake : IAwake, IMonoBinds
    {
    }

    public interface IMonoStart : IStart, IMonoBinds
    {
    }

    public interface IMonoUpdate : IUpdate, IMonoBinds
    {
    }

    public interface IMonoLateUpdate : ILateUpdate, IMonoBinds
    {
    }

    public interface IMonoDestroy : IDestroy, IMonoBinds
    {
    }

    public interface IMonoDispose : IDispose, IMonoBinds
    {
    }

    public interface IMonoFixedUpdate : IFixedUpdate, IMonoBinds
    {
    }
}
