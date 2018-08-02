import com.gitblit.utils.JGitUtils
import org.eclipse.jgit.lib.Repository
import org.eclipse.jgit.transport.ReceiveCommand
import org.eclipse.jgit.transport.ReceiveCommand.Result

logger.info("check_date hook triggered by ${user.username} for ${repository.name}")

Repository r = gitblit.getRepository(repository.name)

def blocked = false

for (ReceiveCommand command in commands) {
    String refName = command.refName
    if (refName != 'refs/heads/master') {
        continue
    }
    logger.info("update file check date: ##${command.oldId.name}##${command.newId.name}")
    def commits = JGitUtils.getRevLog(r, command.oldId.name, command.newId.name)
    def serverTime = (new Date().time / 1000).intValue()
    def commintTime = commits[0].id.getCommitTime()
    logger.info("commitTime : ${commintTime} nowTime: ${serverTime}")
    if (commintTime > serverTime + 3600) {
        command.setResult(Result.REJECTED_OTHER_REASON, "你的本机时间大于服务器时间！")
        blocked = true
        break
    }
}
r.close()

if (blocked) {
    logger.info("break push")
    return false
}
