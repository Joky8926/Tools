import com.gitblit.utils.JGitUtils
import org.eclipse.jgit.lib.Repository
import org.eclipse.jgit.transport.ReceiveCommand

logger.info("theme_res_update hook triggered by ${user.username} for ${repository.name}")

Repository r = gitblit.getRepository(repository.name)

def themeList = []

for (ReceiveCommand command in commands) {
    String refName = command.refName
    if (refName != 'refs/heads/master') {
        continue
    }
    def files = JGitUtils.getFilesInRange(r, command.oldId.name, command.newId.name)
    files.each{
        // logger.info("update file: ${it.path}##${it.name}##${it.changeType}")
        def matcher = it.path =~ "^res_cdn/theme_resource/theme(\\d+)"
        if (matcher.count > 0) {
            String themeId = matcher[0][1]
            if (!themeList.contains(themeId)) {
                themeList.add(themeId)
            }
        }
    }
}
r.close()

if (themeList.size() > 0) {
    logger.info("theme_res_update themeList: ${themeList}")
    String triggerUrl = "http://192.168.1.201:8080/job/package_theme_res/buildWithParameters?token=Hummer2018&theme_ids=" + themeList.join("%20")
    try {
        new URL(triggerUrl).getContent()
    } catch (Exception ex) {
        // logger.info("Catching the exception")
    }
}
