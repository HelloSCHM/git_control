import urllib.request
import re
f = open('D:\\novel4.txt','r')
ff = open('D:\\novel5.txt','w')
#f.write(html + "\n\n")
html = f.read()
html = re.sub("<br /><br />|&nbsp;","",html)
ff.write(html)
print('OK')
f.close()
ff.close()
