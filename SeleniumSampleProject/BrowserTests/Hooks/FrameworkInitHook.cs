using System;
using System.Reflection;
using System.Threading;
using AutomationFramework.Base;
using AutomationFramework.Config;
using AutomationFramework.Utils.Logger;
using AutomationFramework.Utils.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;

namespace SympliAPITests.Hooks
{
    [Binding]
    public class FrameworkInitHook : TestInitializeHook
    {                   

        [BeforeTestRun]
        public static void TestRunSetup()
        {
            #region Init Test Log
            InitializeWebSettings();
            LogHelper.CreateTestLog(Settings.TestLogTarget);
            #endregion

            #region Init Test Report      
            ReportHelper.InitializeTestReport();
            #endregion


        }

        [AfterTestRun]
        public static void TestRunCleanup()
        {
            ReportHelper.TestCleanup();
        }
        
        [BeforeFeature]
        public static void BeforeFeature()
        {
            LogHelper.WriteToLog("++++++++++++++++++++++++++++++++++++++++++++Start Feature ++++++++++++++++++++++++++++++++++++++++++");
            LogHelper.WriteToLog("");
            switch (Settings.TestReportTarget)
            {
                case ReportTarget.Klov:
                    break;
                case ReportTarget.Extent:                   
                    ReportHelper.reportManager.TestFeature = ReportHelper.reportManager.ExtentReport.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);                    
                    break;
                case ReportTarget.Pickles:
                    break;
                case ReportTarget.None:
                    break;
                default:
                    break;
            }
            LogHelper.WriteToLog("Testing Feature ........ " + FeatureContext.Current.FeatureInfo.Title);
            LogHelper.WriteToLog("");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            LogHelper.WriteToLog("++++++++++++++++++++++++++++++++++++++++++++End Feature ++++++++++++++++++++++++++++++++++++++++++++");
            LogHelper.WriteToLog("");
        }

        [BeforeScenario]
        public void InitializeScenario()
        {
            LogHelper.WriteToLog("***************************Test Case Start ********************************************************");
            LogHelper.WriteToLog("");
            switch (Settings.TestReportTarget)
            {
                case ReportTarget.Klov:
                    break;
                case ReportTarget.Extent:                    
                    ReportHelper.reportManager.TestScenario = ReportHelper.reportManager.TestFeature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
                    ReportHelper.reportManager.AssignCategory(ScenarioContext.Current, ReportHelper.reportManager.TestScenario);
                    break;
                case ReportTarget.Pickles:
                    break;                
                default:
                    break;
            }
            LogHelper.WriteToLog("Testing Scenario ........ " + ScenarioContext.Current.ScenarioInfo.Title);
            LogHelper.WriteToLog("");
        }
        
        [AfterScenario]
        public void TestStop()
        {
            LogHelper.WriteToLog("***************************Test Case Ended ******************************************************");
            LogHelper.WriteToLog("");
        }
        
        [BeforeStep]
        public void BeforeTestStep()
        {            
            LogHelper.WriteToLog("--------------------------------------Executing Test Step --------------------------------------");
            LogHelper.WriteToLog("");
            LogHelper.WriteToLog("Test Step executed ........." + ScenarioStepContext.Current.StepInfo.Text);
            LogHelper.WriteToLog("");
        }

        [AfterStep]
        public void AfterEachStep()
        {
            switch (Settings.TestReportTarget)
            {
                case ReportTarget.Klov:
                    break;
                case ReportTarget.Extent:
                    var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

                    PropertyInfo propertyInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
                    MethodInfo methodInfo = propertyInfo.GetGetMethod(nonPublic: true);
                    object testResult = methodInfo.Invoke(ScenarioContext.Current, null);
                    
                    //Pending Step Status
                    if (string.Compare(testResult.ToString(), "StepDefinitionPending", true) == 0)
                    {
                        if (stepType == "Given")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        }
                        else if (stepType == "When")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        }
                        else if (stepType == "Then")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        }
                        else if (stepType == "And")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        }
                        else if (stepType == "But")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        }
                    }
                    else if (ScenarioContext.Current.TestError == null)
                    {                       
                        if (stepType == "Given")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text);
                        }
                        else if (stepType == "When")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text);
                        }
                        else if (stepType == "Then")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text);
                        }
                        else if (stepType == "And")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text);
                        }
                        else if (stepType == "But")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text);
                        }
                    }
                    else if (ScenarioContext.Current.TestError != null)
                    {                        
                        if (stepType == "Given")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        }
                        else if (stepType == "When")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        }
                        else if (stepType == "Then")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        }
                        else if (stepType == "And")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        }
                        else if (stepType == "But")
                        {
                            ReportHelper.reportManager.TestScenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.StepDefinitionType + ": " + ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                        }                        
                    }
                    
                    break;
                case ReportTarget.Pickles:
                    break;                
                default:
                    break;
            }

            LogHelper.WriteToLog("--------------------------------------End of Test Step ------------------------------------------");
            LogHelper.WriteToLog("");
        }
    }
}
