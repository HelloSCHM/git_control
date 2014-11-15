import io
import urllib.request 
import re
name = input('请输入小说名：')
fname = str(name.encode('gb2312'))
fname = re.sub("\\\\x","%",fname)
fname = re.sub("b'|'","",fname)
#name = input("请输入：")
url = "http://www.23us.com/modules/article/search.php?&charset=utf-8articlename=&searchkey="
url += fname
print(url)
page = urllib.request.urlopen(url)
html = page.read()
html = html.decode('GBK')
print(html)

reg = r"(?<=<a class=\"read\" href=\")\S+\b"
urlget = re.compile(reg)
urlg = re.findall(urlget,html)

print (urlg)

os.system(pause)
