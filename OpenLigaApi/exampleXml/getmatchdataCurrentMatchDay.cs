﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api", IsNullable=false)]
public partial class ArrayOfMatch {
    
    private ArrayOfMatchMatch[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Match")]
    public ArrayOfMatchMatch[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api")]
public partial class ArrayOfMatchMatch {
    
    private string lastUpdateDateTimeField;
    
    private string leagueIdField;
    
    private string locationField;
    
    private string matchDateTimeField;
    
    private string matchDateTimeUTCField;
    
    private string matchIDField;
    
    private string matchIsFinishedField;
    
    private string numberOfViewersField;
    
    private string timeZoneIDField;
    
    private ArrayOfMatchMatchGoalsGoal[][] goalsField;
    
    private ArrayOfMatchMatchGroup[] groupField;
    
    private ArrayOfMatchMatchMatchResultsMatchResult[][] matchResultsField;
    
    private ArrayOfMatchMatchTeam1[] team1Field;
    
    private ArrayOfMatchMatchTeam2[] team2Field;
    
    /// <remarks/>
    public string LastUpdateDateTime {
        get {
            return this.lastUpdateDateTimeField;
        }
        set {
            this.lastUpdateDateTimeField = value;
        }
    }
    
    /// <remarks/>
    public string LeagueId {
        get {
            return this.leagueIdField;
        }
        set {
            this.leagueIdField = value;
        }
    }
    
    /// <remarks/>
    public string Location {
        get {
            return this.locationField;
        }
        set {
            this.locationField = value;
        }
    }
    
    /// <remarks/>
    public string MatchDateTime {
        get {
            return this.matchDateTimeField;
        }
        set {
            this.matchDateTimeField = value;
        }
    }
    
    /// <remarks/>
    public string MatchDateTimeUTC {
        get {
            return this.matchDateTimeUTCField;
        }
        set {
            this.matchDateTimeUTCField = value;
        }
    }
    
    /// <remarks/>
    public string MatchID {
        get {
            return this.matchIDField;
        }
        set {
            this.matchIDField = value;
        }
    }
    
    /// <remarks/>
    public string MatchIsFinished {
        get {
            return this.matchIsFinishedField;
        }
        set {
            this.matchIsFinishedField = value;
        }
    }
    
    /// <remarks/>
    public string NumberOfViewers {
        get {
            return this.numberOfViewersField;
        }
        set {
            this.numberOfViewersField = value;
        }
    }
    
    /// <remarks/>
    public string TimeZoneID {
        get {
            return this.timeZoneIDField;
        }
        set {
            this.timeZoneIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Goal", typeof(ArrayOfMatchMatchGoalsGoal), IsNullable=false)]
    public ArrayOfMatchMatchGoalsGoal[][] Goals {
        get {
            return this.goalsField;
        }
        set {
            this.goalsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Group")]
    public ArrayOfMatchMatchGroup[] Group {
        get {
            return this.groupField;
        }
        set {
            this.groupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("MatchResult", typeof(ArrayOfMatchMatchMatchResultsMatchResult), IsNullable=false)]
    public ArrayOfMatchMatchMatchResultsMatchResult[][] MatchResults {
        get {
            return this.matchResultsField;
        }
        set {
            this.matchResultsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Team1")]
    public ArrayOfMatchMatchTeam1[] Team1 {
        get {
            return this.team1Field;
        }
        set {
            this.team1Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Team2")]
    public ArrayOfMatchMatchTeam2[] Team2 {
        get {
            return this.team2Field;
        }
        set {
            this.team2Field = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api")]
public partial class ArrayOfMatchMatchGoalsGoal {
    
    private string commentField;
    
    private string goalGetterIDField;
    
    private string goalGetterNameField;
    
    private string goalIDField;
    
    private string isOvertimeField;
    
    private string isOwnGoalField;
    
    private string isPenaltyField;
    
    private string matchMinuteField;
    
    private string scoreTeam1Field;
    
    private string scoreTeam2Field;
    
    /// <remarks/>
    public string Comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
    
    /// <remarks/>
    public string GoalGetterID {
        get {
            return this.goalGetterIDField;
        }
        set {
            this.goalGetterIDField = value;
        }
    }
    
    /// <remarks/>
    public string GoalGetterName {
        get {
            return this.goalGetterNameField;
        }
        set {
            this.goalGetterNameField = value;
        }
    }
    
    /// <remarks/>
    public string GoalID {
        get {
            return this.goalIDField;
        }
        set {
            this.goalIDField = value;
        }
    }
    
    /// <remarks/>
    public string IsOvertime {
        get {
            return this.isOvertimeField;
        }
        set {
            this.isOvertimeField = value;
        }
    }
    
    /// <remarks/>
    public string IsOwnGoal {
        get {
            return this.isOwnGoalField;
        }
        set {
            this.isOwnGoalField = value;
        }
    }
    
    /// <remarks/>
    public string IsPenalty {
        get {
            return this.isPenaltyField;
        }
        set {
            this.isPenaltyField = value;
        }
    }
    
    /// <remarks/>
    public string MatchMinute {
        get {
            return this.matchMinuteField;
        }
        set {
            this.matchMinuteField = value;
        }
    }
    
    /// <remarks/>
    public string ScoreTeam1 {
        get {
            return this.scoreTeam1Field;
        }
        set {
            this.scoreTeam1Field = value;
        }
    }
    
    /// <remarks/>
    public string ScoreTeam2 {
        get {
            return this.scoreTeam2Field;
        }
        set {
            this.scoreTeam2Field = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api")]
public partial class ArrayOfMatchMatchGroup {
    
    private string groupIDField;
    
    private string groupNameField;
    
    private string groupOrderIDField;
    
    /// <remarks/>
    public string GroupID {
        get {
            return this.groupIDField;
        }
        set {
            this.groupIDField = value;
        }
    }
    
    /// <remarks/>
    public string GroupName {
        get {
            return this.groupNameField;
        }
        set {
            this.groupNameField = value;
        }
    }
    
    /// <remarks/>
    public string GroupOrderID {
        get {
            return this.groupOrderIDField;
        }
        set {
            this.groupOrderIDField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api")]
public partial class ArrayOfMatchMatchMatchResultsMatchResult {
    
    private string pointsTeam1Field;
    
    private string pointsTeam2Field;
    
    private string resultDescriptionField;
    
    private string resultIDField;
    
    private string resultNameField;
    
    private string resultOrderIDField;
    
    private string resultTypeIDField;
    
    /// <remarks/>
    public string PointsTeam1 {
        get {
            return this.pointsTeam1Field;
        }
        set {
            this.pointsTeam1Field = value;
        }
    }
    
    /// <remarks/>
    public string PointsTeam2 {
        get {
            return this.pointsTeam2Field;
        }
        set {
            this.pointsTeam2Field = value;
        }
    }
    
    /// <remarks/>
    public string ResultDescription {
        get {
            return this.resultDescriptionField;
        }
        set {
            this.resultDescriptionField = value;
        }
    }
    
    /// <remarks/>
    public string ResultID {
        get {
            return this.resultIDField;
        }
        set {
            this.resultIDField = value;
        }
    }
    
    /// <remarks/>
    public string ResultName {
        get {
            return this.resultNameField;
        }
        set {
            this.resultNameField = value;
        }
    }
    
    /// <remarks/>
    public string ResultOrderID {
        get {
            return this.resultOrderIDField;
        }
        set {
            this.resultOrderIDField = value;
        }
    }
    
    /// <remarks/>
    public string ResultTypeID {
        get {
            return this.resultTypeIDField;
        }
        set {
            this.resultTypeIDField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api")]
public partial class ArrayOfMatchMatchTeam1 {
    
    private string shortNameField;
    
    private string teamIconUrlField;
    
    private string teamIdField;
    
    private string teamNameField;
    
    /// <remarks/>
    public string ShortName {
        get {
            return this.shortNameField;
        }
        set {
            this.shortNameField = value;
        }
    }
    
    /// <remarks/>
    public string TeamIconUrl {
        get {
            return this.teamIconUrlField;
        }
        set {
            this.teamIconUrlField = value;
        }
    }
    
    /// <remarks/>
    public string TeamId {
        get {
            return this.teamIdField;
        }
        set {
            this.teamIdField = value;
        }
    }
    
    /// <remarks/>
    public string TeamName {
        get {
            return this.teamNameField;
        }
        set {
            this.teamNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/OLDB.Spa.Models.Api")]
public partial class ArrayOfMatchMatchTeam2 {
    
    private string shortNameField;
    
    private string teamIconUrlField;
    
    private string teamIdField;
    
    private string teamNameField;
    
    /// <remarks/>
    public string ShortName {
        get {
            return this.shortNameField;
        }
        set {
            this.shortNameField = value;
        }
    }
    
    /// <remarks/>
    public string TeamIconUrl {
        get {
            return this.teamIconUrlField;
        }
        set {
            this.teamIconUrlField = value;
        }
    }
    
    /// <remarks/>
    public string TeamId {
        get {
            return this.teamIdField;
        }
        set {
            this.teamIdField = value;
        }
    }
    
    /// <remarks/>
    public string TeamName {
        get {
            return this.teamNameField;
        }
        set {
            this.teamNameField = value;
        }
    }
}