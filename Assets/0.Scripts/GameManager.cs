using UnityEngine;

public class GameManager : SingleTon<GameManager>
{ 
   public Light sun;

   public int day;
   private float _time;
   [SerializeField] private float period = 90;
   
   private void Start()
   {
      sun.intensity = 0;
   }
   
   private void Update()
   {
      _time += Time.deltaTime;
   
      sun.intensity = (Mathf.Sin(Time.time * Mathf.PI * 2.0f / period) + 1.0f) * 1.5f;
            
      if (_time >=30)
      {
         _time = 0;
         day++;
      }
   }

   public bool IsNight()
   {
      return sun.intensity <= 1;
   }
}
