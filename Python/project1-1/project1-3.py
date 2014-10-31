import urllib.request
import re
f = open('D:\\novel.txt','r')
ff = open('D:\\novel3.txt','w')
#f.write(html + "\n\n")
html = f.read()
reg = r"(?<=<a href=\")\S+(?=\">)|(?<=.html\">)[\s\S]*?(?=</a></td>)"
urlget = re.compile(reg)
urlg = re.findall(urlget,html)
for index,item in enumerate(urlg):
        #print (index,item)
        
        if index % 2 == 0:
                ff.write(item + "    ")
                #print(item + "    ")        
        else:
                ff.write(item + "\n")
                #print(item + "\n")
print('OK')
f.close()
ff.close()
