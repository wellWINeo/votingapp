using System.ComponentModel;

namespace VotingApp.Web.Models.Entities;

public enum VoteResultsAccess
{
    [Description("Только статистика")]
    OnlyStatistic = 0,
    
    [Description("Анонимные результаты")]
    Anonymous = 1,
    
    [Description("Есть имена пользователей")]
    Transparent = 2,
}