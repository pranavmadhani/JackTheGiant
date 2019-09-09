using System.Collections;

using UnityEngine;

public static class CustomCouritine
{
    public static IEnumerator waitForRealSeconds(float time)
    {
        float startTime = Time.realtimeSinceStartup;

        while(Time.realtimeSinceStartup < (startTime + time))
        {
            yield return null;
        }
    }

    public static IEnumerator waitForSpecificSeconds(float time)
    {
        yield return waitForRealSeconds(time);
    }


}



