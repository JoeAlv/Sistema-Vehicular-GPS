using System.Collections.Generic;

public class LogConditions
{
    public Condition FindCondition(int ConditionID)
    {
        Conditions_CRUD obj = new Conditions_CRUD();
        return obj.FindCondition(ConditionID);
    }

    public List<Condition> ListCondition()
    {
        Conditions_CRUD obj = new Conditions_CRUD();
        return obj.GetConditions();
    }

}
