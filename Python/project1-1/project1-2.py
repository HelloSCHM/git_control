import urllib.request
import re
f = open('D:\\novel.txt','w')
resp=urllib.request.urlopen('http://www.23us.com/html/28/28373/') 
html=resp.read()
html = html.decode('GBK')
#f.write(html + "\n\n")
reg = r"(?<=<td class=\"L\">)[\s\S]*(?=</a></td>)"
urlget = re.compile(reg)
urlg = re.findall(urlget,html)
for index,item in enumerate(urlg):
        #print (index,item)
        f.write(item)
f.write('</a></td>')
print('OK')
f.close()
