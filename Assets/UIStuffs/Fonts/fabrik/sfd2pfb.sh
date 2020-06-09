#!/bin/sh
mkdir -p pfb
echo "Creating PostScript fonts ..."
for font in sfd/*.[Ss][Ff][Dd] ; do
    fontforge ./font2pfb.ff "$font"
done
mv sfd/*.pfb pfb
mv sfd/*.afm pfb
