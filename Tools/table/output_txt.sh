WORKSPACE=$(cd `dirname $0`; pwd)
SOURCETABLEDIR=$WORKSPACE/../../Tables/Sources/
TABLERESDIR=$WORKSPACE/../../UnityProject/DefenceGBL/Assets/StreamingAssets/config

cd $WORKSPACE
printf $WORKSPACE
./convertxlsx -i $SOURCETABLEDIR -o $TABLERESDIR
