# Introduction 
This project is created as a base for Avanade (NL) to create a reusable App Service (incl. App Service Plan) asset.

This solution contains:
- YAML pipelines for CI/CD:
	- Validation
	- Build
	- Develop (TODO: Add Test/Acceptance pre Production)
	- Production
- ARM & Bicep templates for different resources:
	- App Service Plan + App Service Resources
 
# Getting Started
1. Make sure a DevOps environment for each stage exists (currently supported: DEVELOP, PRODUCTION) (https://dev.azure.com/#YourAccount#/#YourProject#/_environments)
2. Make sure a DevOps library for each stage exists (currently supported: DEVELOP, PRODUCTION) (https://dev.azure.com/#YourAccount#/#YourProject#/_library?itemType=VariableGroups)
3. Check if the variable 'ResourceGroupName' exists and is filled with the corresponding pre required Resource Group value (should differ for both DEVELOP and PRODUCTION)
	- If it doesn't exist, create and fill in with the value appropriate for the corresponding pre required Resource Group value (should differ for both DEVELOP and PRODUCTION)
4. Check if the variable 'ServiceConnectionName' exists and is filled with the corresponding pre required Service Connection value (should differ for both DEVELOP and PRODUCTION)
	- If it doesn't exist, create and fill in with the value appropriate for the corresponding pre required Service Connection value (should differ for both DEVELOP and PRODUCTION)
5. Check if the variable 'DtapName' exists and is filled
	- If it doesn't exist, create and fill in with the value appropriate for the D/T/A/P environment you're creating it for (ex: D)
6. Create a new variable per library named 'AspSkuName' and fill with the appropiate tier/SKU value you would like to use (ex: S1)
7. Create/import Repository in Azure Devops to clone/import this
	- Make sure a branch named 'develop' and 'main' exist
8. Create a new Pipeline and select created/imported repo with 'existing Azure Pipelines YAML file' and select branch 'develop' with path to '/iac/Avassets.AppService.Pipeline.yaml'
9. Manually run the pipeline or check in a change to 'develop' branch to trigger the pipeline

# Prerequisites
- [Azure DevOps](https://dev.azure.com/)
- Azure DevOps Service Connection (https://dev.azure.com/#YourAccount#/#YourProject#/_settings/adminservices)
- Azure DevOps Environments
	- DEVELOP
	- PRODUCTION
- Azure DevOps Libraries
	- DEVELOP
	- PRODUCTION
- Azure Resource Group(s)