using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BossParametrs : LiveParametrs
{
    #region BOSS EVENTS
    //событие для отслеживание получения урона, если здоровье изменилось более чем на 5%, босс включает один из скиллов
    public delegate void BossTakeDamage(float oldHealthValue, float newHealthValue);
    public event BossTakeDamage bossTakeDamageEvent;

    //событие для смены фазы босса
    public delegate void ChangePhase(float newHealthValue);
    public event ChangePhase changeBossPhaseEvent;
    #endregion 


    public override void TakeDamage(string typeDamage, float damage)
    {
        float oldHealthValue = health;
        base.TakeDamage(typeDamage, damage);

        changeBossPhaseEvent?.Invoke(health);
        bossTakeDamageEvent?.Invoke(oldHealthValue, health);
    }

}
