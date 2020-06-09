#!/bin/sh
ARCHIV="../fabrik_"`date -I | tr -d "-"`
rm sfd/*.sfd~ doc/*.eps
. ./sfd2ttf.sh
. ./sfd2otf.sh
. ./sfd2pfb.sh
rm sfd/*.afm
echo $ARCHIV
zip -r $ARCHIV sfd/ ttf/ otf/ pfb/ doc/ scripts/ *.txt *.ff *.sh
