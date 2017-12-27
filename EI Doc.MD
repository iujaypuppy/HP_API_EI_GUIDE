# EI DEV GUIDE
## Introduction

## Preparation
### Concept
1. Apache CXF
    * Configuration
    * Log
        * Inbound Message
        * Outbound Message
    * Security
    * Demo
2. Web Service
    * WSDL
        * SOAP
    * Security
        * SAML
        * SSL
3. Log4j

### Software
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

## Getting Started
### Solman Setup
* Install Sap Logon
* Add connection to Solman server. Avaiable servers in below table can be used.

### EI Setup

## Terms
### Solution Manager (Solman)
#### Transaction Code 
* solman_setup
    * Exchange WSDL for Solman and EI
    * 
* solman_workcenter
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
### Application Lifecycle Management (ALM)
### Enterprise Intergration (EI)

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

* [SAP servers](https://rndwiki.houston.softwaregrp.net/confluence/display/UFT/SAP+Environments)

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

* [Database Servers](https://rndwiki.houston.softwaregrp.net/confluence/pages/viewpage.action?pageId=122034777)

DB Type | Server | Account | Comment
--------|--------|---------|--------
SQL Server | 16.186.77.172 | sa/1Qaz2wsx3edc | jdbc:mercury:sqlserver://16.186.77.172:1433
Oracle | 16.155.198.156 | system/W3lcome1 |  jdbc:mercury:oracle://16.155.198.156:1521;servicename=orcl.hpeswlab.net

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












