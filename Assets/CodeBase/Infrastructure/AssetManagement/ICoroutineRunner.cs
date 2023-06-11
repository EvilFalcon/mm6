using System.Collections;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}