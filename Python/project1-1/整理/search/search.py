# -*- coding:utf-8 -*-
import urllib.request 
import re
f = open('D:\\search.txt','r').read()
name = f
print(name)
#name = input("请输入：")
try:
    url = "http://www.23us.com/modules/article/search.php?&charset=utf-8articlename=&searchkey="
    url += name
    print(url)
    #s = url.encode('GBK')
    #u = url.decode('utf-8')
    #print(u)
    page = urllib.request.urlopen(url)
    html = page.read()
    print(html)
    reg = r"(?<=<a class=\"read\" href=\")\S+\b"
    urlget = re.compile(reg)
    urlg = re.findall(urlget,html)

    print (urlg)
finally:
    print('输入小说未找到，请检查后重试~')
