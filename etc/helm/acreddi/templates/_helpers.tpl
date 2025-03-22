,
{{- define "acreddi.hosts.webpublic" -}}
{{- print "https://" (.Values.global.hosts.webpublic | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "acreddi.hosts.web" -}}
{{- print "https://" (.Values.global.hosts.web | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "acreddi.hosts.httpapi" -}}
{{- print "https://" (.Values.global.hosts.httpapi | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "acreddi.hosts.authserver" -}}
{{- print "https://" (.Values.global.hosts.authserver | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
