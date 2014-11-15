import urllib.request
import re
f = open('url.txt','r')
import search-end.py
resp=urllib.request.urlopen(f.read()) 
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
