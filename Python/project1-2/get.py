# -*- coding:utf-8 -*-
import urllib.request
import re,os

page = urllib.request.urlopen("http://tieba.baidu.com/p/1859019972?see_lz=1")
html = page.read()
html = html.decode('utf-8')

regs = r"<h1 class=\"core_title_txt  \" title=\"(.*?)\""
namel = re.compile(regs)
name = re.findall(namel,html)[0]
if os.path.exists(name):
    print('文件已存在')
else:
    os.mkdir(name)
    
reg = r"<img class=\"BDE_Image\" src=\"(.*?\.jpg)\""
#此处为正则表达式，用于匹配页面中的图片链接，不同的网页图片链接的格式有所不用，此处需按需调整
imgre = re.compile(reg)
imglist = re.findall(imgre,html)
#print(imglist)
x = 1
for imgurl in imglist:
      urllib.request.urlretrieve(imgurl,name + '\\' + '%s.jpg' % x  )
      print ("第",x,"张下载完成！")
      x+=1

