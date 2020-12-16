# ![Logo](art/ZenMvvm.WeakEventHelpers-64x64.png) ZenMvvm.WeakEventHelpers
Description here

[![Coverage](https://raw.githubusercontent.com/zenmvvm/ZenMvvm.WeakEventHelpers/develop/coverage/badge_linecoverage.svg)](https://htmlpreview.github.io/?https://raw.githubusercontent.com/zenmvvm/ZenMvvm.WeakEventHelpers/develop/coverage/index.html) [![NuGet](https://buildstats.info/nuget/ZenMvvm.WeakEventHelpers?includePreReleases=false)](https://www.nuget.org/packages/ZenMvvm.WeakEventHelpers/)


A Template solution directory with:

* .NET Standard 2.0 project, and
  * Best for libraries. Everything uses this API. But no implementation so only good for libraries 
* .NET 5 Unit Test project (implementation that now replaces  .NET Core 3.1 target framework)
  * Have to have an implementation for a unit test runner. So .NET 5 is simple... and fully compatable with .NET Standard

## ToDo 

* Add Test Helpers

* update CI if new dependabot script more robust

  * ```
      dependabotautomerge:
        # from https://localheinz.com/blog/2020/06/15/merging-pull-requests-with-github-actions/
        needs: build
        if: >
          github.event_name == 'pull_request' &&
          github.event.pull_request.draft == false && (
            github.event.action == 'opened' ||
            github.event.action == 'reopened' ||
            github.event.action == 'synchronize'
          ) && (
          github.actor == 'dependabot[bot]'
          )
        runs-on: ubuntu-latest
        steps:
          - name: automerge
            uses: actions/github-script@0.2.0
            with:
              script: |
                const pullRequest = context.payload.pull_request
                const repository = context.repo
                await github.pulls.merge({
                  merge_method: "merge",
                  owner: repository.owner,
                  pull_number: pullRequest.number,
                  repo: repository.repo,
                  })
              github-token: ${{github.token}}
    ```

  * 

## Steps:

Download this repo as zip file

Rename root folder name

* Open GitKraken

* Init
  * Name project same
  * Select root folder so that it over-rides / matches the existing folder
  * Don't select gitignore or license as already there
  * Should open with initial commit and bunch of unstaged changes
* STAGE all but .github file workflows/main.yml
  * this can't be pushed / updated to remote due to security concerns
* Amend initial commit

* Push
  * Will ask you to create a remote... do so with your account

***

* Run rename-project.command
  
  * Will rename within files, filenames and directories
  
  * MacOS security gives issues
  
  * ```bash
    sudo chmod 755 rename-project 
    ls -l
    # now should see x for execute
    ./rename-project 
    ```
  
* Review changes in version-history, and ammend intial commit
* Force push to server

***

Ensure local and remote are synced (except for unstageed main.yml file)

Login to github online and Create Github action

* copy content from the local main.yml file into the action
* commit file in git-online
* delete local version
* In GitKraken Pull remote from local



Initialise Gitflow and switch to develop branch

## Command line option

```bash
# Download from Github
curl --location --remote-name https://github.com/z33bs/ZenMvvm.WeakEventHelpers/archive/master.zip
unzip master.zip
git archive https://github.com/z33bs/ZenMvvm.WeakEventHelpers
wget https://github.com/z33bs/ZenMvvm.WeakEventHelpers/archive/master.zip

// Clone the repo
git clone --depth=1 git://someserver/somerepo dirformynewrepo
// Remove the .git directory
rm -rf !$/.git

git clone https://github.com/z33bs/ZenMvvm.WeakEventHelpers
rm -rf .git

# You can install xclip using `apt-get`
apt-get install xclip
xclip -sel c < file

```

### Works

```bash
git clone https://github.com/z33bs/ZenMvvm.WeakEventHelpers NewName
cd NewName
rm -rf .git
# do project renaming stuff
rm rename-project

git init
git add .
# git status

# create new branch main
# will only be able to see when committed
git checkout -b main
# git branch -m main
git commit -m 'Initial commit'
git branch --list

# create remote
curl -u 'z33bs' https://api.github.com/user/repos -d '{"name":"NewName"}'

git remote add origin https://github.com/z33bs/NewName
git push -u origin master
# Can only create worker afterward
cat main.yml | pbcopy 
```



NET library template with continuous integration

tests

code coverage

badges

