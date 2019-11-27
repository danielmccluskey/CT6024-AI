﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////////////////
//Created by: Daniel McCluskey
//Project: CT6024 - AI
//Repo: https://github.com/danielmccluskey/CT6024-AI
//Script Purpose: Makes the guard patrol its area
//////////////////////////////////////////////////////////////////
public class CS_GuardPatrolAction : CS_GOAPAction
{
    private bool m_bRequiresInRange = true;

    private bool m_bisPatrolling = false;

    public CS_GuardPatrolAction()
    {
        AddPreCondition("seePlayer", false);
        AddEffect("secureArea", true);
        m_fCost = 1.0f;
    }

    public override void ResetGA()
    {
        m_bisPatrolling = false;
        m_goTarget = null;
    }

    public override bool IsActionFinished()
    {
        return m_bisPatrolling;
    }

    public override bool NeedsToBeInRange()
    {
        return m_bRequiresInRange;
    }

    public override bool CheckPreCondition(GameObject agent)
    {
        m_goTarget = GetComponent<CS_Guard>().GetCurrentPatrolPoint();

        if (m_goTarget != null)
        {
            return true;
        }

        return false;
    }

    public override bool PerformAction(GameObject agent)
    {
        m_bisPatrolling = true;
        GetComponent<CS_Guard>().NextPatrolPoint();
        return true;
    }

    public void InvestigationMode(bool a_bTrue)
    {
        if (a_bTrue)
        {
            m_fCost = 25;
        }
        else
        {
            m_fCost = 100;
        }
    }
}