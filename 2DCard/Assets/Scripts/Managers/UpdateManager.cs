using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 기존의 유니티 Update 시스템을 대처하기 위해 만든 UpdateSystem
/// </summary>
public class UpdateManager : MonoSingleton<UpdateManager>
{
    //  readonly?
    //  생성 및 생성자에서 값을 변경할 수 있다
    //  다음부터는 값 변경이 불가
    public readonly struct UpdateValue
    {
        public UpdateValue(IEnumerator routine, Action callback)
        {
            this.routine = routine;
            this.callback = callback;
        }

        public readonly IEnumerator routine;
        public readonly Action callback;
    }

    private List<UpdateValue> updateValues = null;

    public static void Add(IEnumerator routine, Action callback = null)
        => Get.updateValues.Add(new UpdateValue(routine, callback));

    public static void Remove(IEnumerator routine)
        => Get.updateValues.Remove(Get.updateValues.Find(x => x.routine.Equals(routine)));

    public static void Clear()
        => Get.updateValues.Clear();

    private void Awake()
        => updateValues = new List<UpdateValue>();

    private void Update()
    {
        for (int i = 0; i < updateValues.Count; ++i)
        {
            if (!updateValues[i].routine.MoveNext())
            {
                updateValues[i].callback?.Invoke();
                updateValues.RemoveAt(i--);
            }
        }
    }

}
