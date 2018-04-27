using System;
using System.Collections.Generic;
using System.Text;

public class Mission : IMission
{
    private string codeName;
    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName
    {
        get { return this.codeName; }
        private set { this.codeName = value; }
    }

    public string State
    {
        get { return this.state; }
        private set { this.state = value; }
    }

    public bool CompleteMission()
    {
        return false;
    }

    public override string ToString()
    {
        return $"  Code Name: {this.CodeName} State: {this.State}";
    }
}
