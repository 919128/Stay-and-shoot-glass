using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class MyNotific : MonoBehaviour
    {

        [SerializeField] string[] messages;
        void Start()
        {
            if (!PlayerPrefs.HasKey("Sended"))
            {
                for (int i = 0; i < messages.Length; i++)
                {
                    var notificationParams = new NotificationParams
                    {
                        Id = UnityEngine.Random.Range(0, int.MaxValue),
                        Delay = i == 0 ? TimeSpan.FromHours(2) : TimeSpan.FromDays(i),//TimeSpan.FromSeconds(5) : TimeSpan.FromSeconds(i * 10),//
                        Title = messages[i],
                        Message = messages[i],
                        Ticker = "Ticker",
                        Sound = true,
                        Vibrate = true,
                        Light = true,
                        SmallIcon = NotificationIcon.Heart,
                        SmallIconColor = new Color(0, 0.5f, 0),
                        LargeIcon = "app_icon"
                    };

                    NotificationManager.SendCustom(notificationParams);

                }
                PlayerPrefs.SetInt("Sended", 1);
            }
        }
   


    }

}
