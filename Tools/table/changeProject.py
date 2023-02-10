

oldProjectName = "SuperStudio"
newProjectName = "RichestLengend"


path_csharpBat = "output_code_csharp.bat"
path_csharpSh = "output_code_csharp.sh"
path_txtBat = "output_txt.bat"
path_txtSh = "output_txt.sh"
path_txtunixSh = "output_txt_unix.sh"


paths = [path_csharpBat,path_csharpSh,path_txtBat,path_txtSh,path_txtunixSh]


for path in paths:
	fo = open(path , "r");
	lines = fo.readlines()
	f_w = open(path , "w")
	
	for line in lines:
		
		line = line.replace(oldProjectName,newProjectName)
		# print(line)
		f_w.write(line)
	fo.close()
	f_w.close()
	print(path+":Complete")
