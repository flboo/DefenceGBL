WORKSPACE=$(cd `dirname $0`; pwd)
SOURCETABLEDIR=$WORKSPACE/../../Tables/Sources/
TABLERESDIR=$WORKSPACE/../../UnityProject/DefenceGBL/Assets/StreamingAssets/config

cd $WORKSPACE
printf $WORKSPACE
chmod -R 777 ./xlsxconvert
python ./xlsxconvert/convertxlsx.py -i $SOURCETABLEDIR -o $TABLERESDIR
