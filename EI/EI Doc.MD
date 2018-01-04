# EI DEV GUIDE

<!-- TOC -->

- [EI DEV GUIDE](#ei-dev-guide)
    - [Introduction](#introduction)
        - [Application Lifecycle Management (ALM)](#application-lifecycle-management-alm)
        - [Enterprise Intergration (EI)](#enterprise-intergration-ei)
        - [Solution Management (Solman)](#solution-management-solman)
    - [Getting Started](#getting-started)
        - [Preparation](#preparation)
            - [Concept](#concept)
            - [Software](#software)
        - [Solman Setup](#solman-setup)
        - [EI Setup](#ei-setup)
    - [Environment Configuration](#environment-configuration)
    - [Terms](#terms)
        - [Solman](#solman)
            - [Transaction Code](#transaction-code)
        - [ALM](#alm)
            - [Requirement](#requirement)
            - [Test](#test)
            - [Test Set](#test-set)
            - [Defect](#defect)
            - [Version Control](#version-control)
        - [EI](#ei)
            - [Solman 7.2 feature](#solman-72-feature)
                - [Sync and merge](#sync-and-merge)
                - [Content activation](#content-activation)
                - [BPCA](#bpca)
                - [Audit Log](#audit-log)
    - [Strcuture](#strcuture)
        - [EI Code Structure](#ei-code-structure)
            - [Server Backend](#server-backend)
            - [Server Frontend](#server-frontend)
            - [Important Files](#important-files)
            - [Important Paths](#important-paths)
        - [EI & Solman & ALM Communication Strcuture](#ei--solman--alm-communication-strcuture)
        - [EI & Solman & ALM Web Service Structure](#ei--solman--alm-web-service-structure)
    - [Others](#others)
        - [Links](#links)
        - [Resources](#resources)
        - [Emails for Consult](#emails-for-consult)

<!-- /TOC -->

## Introduction
### Application Lifecycle Management (ALM)
* Application Lifecycle Management (ALM) empowers organizations to manage the core application lifecycle, from requirements through deployment, granting application teams the crucial visibility and collaboration needed for predictable, repeatable, and adaptable delivery of modern applications.
* It includes tools for **requirements management**, **test planning** and **functional testing**, **performance testing**(when used with HP Performance Center), developer management (through integration with the most widely used developer environments such as Collabnet, TeamForge and Microsoft Visual Studio), and **defect management**.
* [Wiki](https://en.wikipedia.org/wiki/HP_Application_Lifecycle_Management)
* [Online Help](http://admhelp.microfocus.com/alm/en/latest/online_help/Content/Resources/_TopNav/_TopNav_Home.htm#)
### Enterprise Intergration (EI)
* An **extension** over ALM that works with SAP Solution Manager Adapter
* [Online Help](http://admhelp.microfocus.com/alm/en/latest/online_help/Content/EI_User.htm)
### Solution Management (Solman)
* SAP Solution Manager is an integrated platform to align business and IT on one business process landscape and drive the “business of IT” from a common understanding of business value, business models, operating models and solution powered by IT.
* [Wiki](https://en.wikipedia.org/wiki/SAP_Solution_Manager)
* [Online Help](https://support.sap.com/en/solution-manager.html)

## Getting Started
### Preparation
#### Concept
1. Apache CXF [ More ...](http://cxf.apache.org/)
    * Configuration
    * Log [More ...](http://cxf.apache.org/docs/configuration.html)
        * Inbound Message
        * Outbound Message
    * Security
    * Demo [More ...](https://github.com/apache/cxf/tree/master/distribution/src/main/release/samples)
        * `sts` with SAML & SSL [More...](https://github.com/apache/cxf/tree/master/distribution/src/main/release/samples/sts)
2. Web Service
    * WSDL
        * SOAP
    * Security
        * SAML
        * SSL
3. Log4j

#### Software
* Essence
    * Java Env: JRE * JDK
    * Java IDE: Eclipse | IDEA
    * Visual Studio
    * Sap Logon
    * Maven & Ant
    * Git
* Tool
    * Everything: quick search
    * Jd-gui: decompiler
    * Remote Desktop Connection Manager: Easy to connect to VMs
    * Editor: Notepad++ | Sublime | VSCode | ...


### Solman Setup
1. Install Sap Logon
2. Add connection to Solman server. Avaiable servers in [below table](#resources) can be used.

### EI Setup
1. Install all necessary softwares
    * Install Visual studio
    * Set up Java environment: JDK & JRE
    * Set up Maven & Ant environment
    * Install git
2. Download EI code from **Stash**
3. Add [`settings.xml`](/EI/Resources) to **.m2** folder to make all maven dependencies work
4. Add run configurator for `set up`
    ```Set up main class
    com.hp.alm.platform.siteadmin.setup.Setup
    ```
5. Add `DB configurator`. Avaiable servers in [below table](#resouces) can be used.
6. Run `Ant build` according to the sequence: APM -> EI
7. Add run configurator for `Jetty Runner`
    * **VM options**
    ```jetty runner VM options
   	-Dmercury.td.sa_config_dir=C:\Users\jiezhang\Documents\HP_EI\Code\site_admin
	-Xmx512m
	-XX:MaxPermSize=512m
	-Djava.io.tmpdir=C:\temp\ALM_log
    ``` 
    * **Program arguments**
    ```jetty runner program arguments
    --defaultroot
	C:\Users\jiezhang\Documents\HP_EI\Tools\masterSSL\defaultroot
	C:\Users\jiezhang\Documents\HP_EI\Tools\masterSSL\StaticData
    C:\Users\jiezhang\Documents\HP_EI\Tools\masterSSL\20qcbin.war
    ```
    * Defaultroot and StaticData can be accessed from **rubicon** 
    ```
    \\mydastr01.hpeswlab.net\products\TestDirector\ALMDev\ALM_Sarah\stabs\alm1221patches\Archives\12.21.4990.0.0\Development_StaticData\TDServer)
    ```
    * 20qcbin.war should be combined with APM and EI. 
        * QC_for_SAP EI
        ```
        \\mydastr01.hpeswlab.net\products\QC_for_SAP\EI\EI12.00\alm1221patch05.latest\SPI.qcx\application\20qcbin.war)
        ```
        * QC_for_SAP APM 
        ```
        \\mydastr01.hpeswlab.net\products\QC_for_SAP\APM\APM12.00\alm1221patch05.latest\APM.qcx\application\20qcbin.war)
        ```

8. Add run configurator for Saml `EIConfigurator`
    * **VM options**
    ```EI configurator vm options
    -Dmercury.td.sa_config_dir=C:\Users\jiezhang\Documents\HP_EI\Code\site_admin
	-Djava.io.tmpdir=C:\temp\ALM_log
    ```
    * **Program arguments**
    ``` EI configurator program arguments
    -gui C:\Users\jiezhang\Documents\HP_EI\Tools\masterSSL\20qcbin.war\WEB-INFO
    ```
9. More[ Link1...](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/EI+Integration#EIIntegration-DevEnvironment)[ Link2...](https://note.youdao.com/share/?id=8b54c7148c6330fc9f7f5ee5960dc96d&type=notebook#/16C1507F14294B5693DC44A727814861)

## Environment Configuration
1. Exchange WSDL
2. Set up security
3. Create project in Solman and ALM
4. Do association
5. Push blueprints
6. Synchronize defects
7. Update test results
8. Sync and merge
9. Do BPCA -- test set
10. Content activation -- Migration from version upgrade
10. More -- Reference doc
    * [Solman 7.1](/EI/Documents/7.1)
        * `EI Sanity.mht` for step 1-7
    * [Solman 7.2](/EI/Documents/7.2)
        * `Partner Test Management - Setup Guide.pdf` for step 1
        * `Partner_Test_Management_SAML2_Configuration.pdf` for step 2
        * `Partner_Test_Management_Adapter_Operations.pdf` for step 3-8
        * `ActivationGuide_SolMan72.pdf` for step 10
        * `Business Process Change Analyzer How to Guide.pdf` for step 9

## Terms
### Solman
#### Transaction Code 
* `solman_setup`
    * Exchange WSDL for Solman and EI
    * 
* `sm_workcenter`
    * Create Association
    * Push blueprint
* se16:
    * AGS_ADT_EVENTS: //TODO
    * AGS_AGS_MAPPING: unlock activity such as "pushing blueprints" or "Content Activation"
* sm12:
    * unlock user
* sm37: 
    * Job log
* srt_util
    * Payload log for web service reuqest and response
* soldoc
* soladm
* soamanager
    * blueprint logic port
    * service desk mqc logic port
* solar_project_admin
    * create solman project
    * create association for Solman and EI
* solar01
    * check blueprint
    * check test result
* ictconf
    * service desk logic port
* crm_ui
    * manage defects
* [**More...**](https://note.youdao.com/share/?id=1ea4010d685f42794bb1ba6c6b0b1890&type=note#/)
### ALM
#### Requirement
#### Test
#### Test Set
#### Defect
#### Version Control

### EI
#### Solman 7.2 feature
* [Wiki](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/Solution+Manager+7.2)
##### Sync and merge
* [Sync](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/Test+Sync): base->child
* merge: child->base
* Process
    * [Copy tests](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/Tests+Copy)
    * [Copy linkage](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/Tests+Linkage)
##### Content activation
##### BPCA
##### Audit Log
* [Wiki](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/Transfer+Log)

## Strcuture
### EI Code Structure
#### Server Backend
* EI Projects under ***/assets/Backend/Server***
    * `EIConfigurator`
    * `ei-jetty-runner`
    * `EIServerCommon`
    * `EIServerCore`
    * `QCServer` -> `SPI`
    * `SPICore`
#### Server Frontend
* C# Solution **EnterpriseIntegration.sln** under ***/assets/Backend/Client/EnterpriseIntegration***
    * `EnterpriseIntegration`
    * `EnterpriseIntegrationUI`
#### Important Files
* log4j.properties
* crypto.properties
* HPEI.keystore
* SAMLClientRepository.xml
* SMFiledsMetaData.xml
#### Important Paths
* webapps\qcbin\WEB-INF\classes 
* webapps\qcbin\Install\Extensions 
### EI & Solman & ALM Communication Strcuture
### EI & Solman & ALM Web Service Structure

## Others
### Links

Description | Address | Comment
------------|---------|--------
**Grok** | http://16.186.74.166:8800/source/ | Quick search for EI code
**Stash** | https://github.houston.softwaregrp.net/EIAP/ | EI code repository
**Jenkins** | http://mydtbld0093.hpeswlab.net:8888/jenkins/view/3rd-Party/ | EI build engine 
Wiki | https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/EI+Integration | EI wiki 
AGM | https://agilemanager-int.saas.hpe.com/agm/webui/alm/t135346750_hp_com/UFT/apm/ | User story and defect management
CPE | http://alm7f.houston.softwaregrp.net/qcbin/ | Customer cases management
ALM | \\mydastr01.hpeswlab.net\products\TestDirector\ALMDev\ | download ALM server

### Resources

* [SAP servers](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/SAP+Environments "More...")

Solman Version | Server | Account | Comment
---------------|--------|---------|--------
7.1 | S71: labm3ftrnd12.hpeswlab.net, IP: 16.44.49.219 | jason1/mercury | Responsibility in Service Desk not work well, SAP ticket 297015 / 2017
7.2 SP03 | S72: mydwbld0145g.hpeswlab.net, IP: 16.19.200.40 | qa01/mercury12 | Only work with ALM 12.53 Patch 1
7.2 SP04* | SLM: SELSOLMAN01.hpeswlab.net, IP: 16.165.218.212 | qa01/123456 | Stable to use
7.2 SP05 |  SL7: MYDPH0233.hpeswlab.net, IP: 16.44.49.214 | qa01/123456 | Instance number:02

* [ALM servers]()

ALM Version | Server | Machine Account | Project Account | Comment
------------|--------|-----------------|-----------------|--------
12.53 patch1 | myd-vm00899.hpswlabs.adapps.hp.com IP: 16.60.157.20 | HPESWLAB\bwang9 / W3lcome7  | qa/qa | Migrated Project M899S3
12.53 patch2 + hotfix | shcuft16.hpeswlab.net IP: 16.155.198.156 |  admin / 1Qaz2wsx3edc | qa/qa | Oracle is installed locally.
12.55* | myd-vm00386.hpswlabs.adapps.hp.com IP: 16.59.58.138 | HPESWLAB\bwang9 / W3lcome7  | qa/qa | QA Environment
12.01 | IP: 16.186.79.79 | appsadmin / appsadmin | sa/ | QA Environment
12.55 patch1 | IP: 15.119.82.83 | administrator / iso*help | sa/ | QA Environment
12.01 | shcuftdev003.hpeswlab.net IP: 16.155.194.105 | appsadmin / appsadmin | sa/ | DEV Environment
12.55* | IP: 16.165.217.185 | admin / 1Qaz2wsx3edc | sa/ | DEV Environment

* [Database Servers](https://rndwiki.houston.softwaregrp.net/confluence/pages/viewpage.action?pageId=122034777 "More...")

DB Type | Server | Account | Comment
--------|--------|---------|--------
SQL Server | 16.186.77.172 | sa/1Qaz2wsx3edc | jdbc:mercury:sqlserver://16.186.77.172:1433
Oracle | 16.155.198.156 | system/W3lcome1 |  jdbc:mercury:oracle://16.155.198.156:1521;servicename=orcl.hpeswlab.net
SQL Server | EI2008R2.hpeswlab.net\EISQL2008R2 | sa\1Qaz2wsx3edc | port = 1443

### Emails for Consult
Type | Name | Email | Comment
-----|------|-------|--------
ALM Server | Du, Yong-Chuang (Charley) | yong-chuangd@hpe.com | Experted at Sync and merge
ALM Server | Li, Cheng-Hui (Allen) | cheng-hui.li@hpe.com | 
ALM Server | Liu, Yang (Carl) | yang.liu@hpe.com |
ALM Client | Wu, Sheng-shen (Sean) | sheng-shen.wu@hpe.com |
EI Dev | Xu, Chengzhe (Jason) | chengzhe.xu@hpe.com | Familiar with EI 7.1
EI Dev | Rafalovich, Maya | mayar@hpe.com | EI expert for many years
EI QA | Chen, Xin-Yuan (Mandy) | xin-yuanc@hpe.com | QA expert
Jenkins | Ding, Chen  | chen.ding@hpe.com | ALM Devops
Jenkins | Zhou, Weijia (Eric) | weijia.zhou@hpe.com | ALm Devops and responsible for EI
Stash | Peleg, Ronen | peleg@hpe.com | Push access for EI git repository
